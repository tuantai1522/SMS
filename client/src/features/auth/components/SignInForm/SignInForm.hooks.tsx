import { useNavigate, useRouter } from "@tanstack/react-router";
import { useSignIn } from "../../hooks/mutations/useSignIn";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { signInFormSchema, type SignInFormSchema } from "./SignInForm.schema";
import { useAuthStore } from "../../stores/auth.store";
import { queryClient } from "../../../shared/lib/queryClient";

export function useSignInForm() {
  const navigate = useNavigate();
  const router = useRouter();

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

        navigate({ to: "/dashboard" });
      },
      onError: (error) => {
        // toast({
        //   title: "Error",
        //   description: error.message,
        //   variant: "destructive",
        // });
      },
    });
  });

  return { form, handleSubmit, isLoading: signInMutation.isPending };
}
