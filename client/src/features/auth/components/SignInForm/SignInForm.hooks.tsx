import { useNavigate, useRouter } from "@tanstack/react-router";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { signInFormSchema, type SignInFormSchema } from "./SignInForm.schema";
import { useAuthStore } from "../../stores/auth.store";
import { queryClient } from "../../../shared/lib/queryClient";
import { useToast } from "../../../shared/hooks/useToast";
import { useMutation } from "@tanstack/react-query";
import { signIn } from "../../apis/signIn.api";
import type { SignInResponse } from "../../types/signIn.types";
import type { BaseResult } from "../../../shared/types/baseResult.types";

export function useSignInForm() {
  const navigate = useNavigate();
  const router = useRouter();

  const { toast } = useToast();

  const signInMutation = useMutation({
    mutationFn: signIn,
    async onSuccess(res) {
      setToken(res.data!.token);

      await queryClient.invalidateQueries({ queryKey: ["me"] });

      await router.invalidate();

      await navigate({ to: "/" });
    },
    async onError(error: BaseResult<SignInResponse>) {
      const apiError = error.errors;

      const message = apiError?.map((e: any) => e.description).join(", ");

      toast({
        title: "Error",
        description: message || "Invalid request",
        variant: "destructive",
      });
    },
  });

  const form = useForm<SignInFormSchema>({
    resolver: zodResolver(signInFormSchema),
    defaultValues: {
      email: "",
      password: "",
    },
  });
  
  const setToken = useAuthStore((s) => s.setAccessToken);

  const handleSubmit = form.handleSubmit(
    async (payload) => await signInMutation.mutateAsync(payload)
  );

  return { form, handleSubmit, isLoading: signInMutation.isPending };
}
