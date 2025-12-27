import { useForm } from "react-hook-form";
import { signInSchema, type SignInFormValues } from "../schemas/signIn.schema";
import { zodResolver } from "@hookform/resolvers/zod";
import { useNavigate, useRouter } from "@tanstack/react-router";
import { useAuthStore } from "../stores/auth.store";
import { useState } from "react";
import { useMutation } from "@tanstack/react-query";
import { signIn } from "../apis/signIn.api";
import type { ApiError } from "../../shared/types/baseResult";

export function useSignIn() {
  const form = useForm<SignInFormValues>({
    resolver: zodResolver(signInSchema),
    defaultValues: {
      email: "",
      password: "",
      rememberMe: false,
    },
    mode: "onTouched",
  });

  const router = useRouter();
  const navigate = useNavigate();
  const setToken = useAuthStore((s) => s.setAccessToken);

  const [errorMessage, setErrorMessage] = useState<string | undefined>(
    undefined
  );

  const { mutate, isPending } = useMutation({
    mutationFn: signIn,
    onSuccess: async (res) => {
      if (res.success && res.data) {
        setToken(res.data.token);

        router.invalidate();

        navigate({ to: "/", replace: true });
        return;
      }

      const message = res?.errors
        ?.map((err: ApiError) => err.description)
        .join(", ");

      setErrorMessage(message);
    },
  });

  const handleSubmit = form.handleSubmit((payload) => mutate(payload));

  return {
    form,
    handleSubmit,
    errorMessage,
    isPending,
  };
}
