import { useNavigate, useRouter } from "@tanstack/react-router";
import { useSignIn } from "../../hooks/mutations/useSignIn";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { signInFormSchema, type SignInFormSchema } from "./SignInForm.schema";
import { useAuthStore } from "../../stores/auth.store";
import { queryClient } from "../../../shared/lib/queryClient";
import { useToast } from "../../../shared/hooks/useToast";

export function useSignInForm() {
  const navigate = useNavigate();
  const router = useRouter();

  const { toast } = useToast();

  const signInMutation = useSignIn();

  const form = useForm<SignInFormSchema>({
    resolver: zodResolver(signInFormSchema),
    defaultValues: {
      email: "",
      password: "",
    },
  });
  const setToken = useAuthStore((s) => s.setAccessToken);

  const handleSubmit = form.handleSubmit(async (data) => {
    signInMutation.mutateAsync(data, {
      onSuccess: async (data) => {
        setToken(data.data!.token);

        queryClient.removeQueries({ queryKey: ["me"] });

        // this re-runs all beforeLoad guards
        router.invalidate();

        navigate({ to: "/" });
      },
      onError: (error) => {
        const apiError = error.response?.data;

        const message = apiError?.errors?.map((e) => e.description).join(", ");

        toast({
          title: "Error",
          description: message || "Invalid request",
          variant: "destructive",
        });
      },
    });
  });

  return { form, handleSubmit, isLoading: signInMutation.isPending };
}
