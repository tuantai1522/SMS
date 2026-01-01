import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { useNavigate } from "@tanstack/react-router";
import { useState } from "react";
import { useMutation, useSuspenseQuery } from "@tanstack/react-query";
import type { ApiError } from "../../shared";
import { getGoogleAuthenticationUrlQueryOptions } from "../queries/getGoogleAuthenticationUrlQueryOptions";
import { signUpSchema, type SignUpFormValues } from "../schemas/signUp.schema";
import { signUp } from "../apis/signUp.api";
import { useToast } from "../../shared/hooks";

export function useSignUp() {
  const { data: googleUrl } = useSuspenseQuery(
    getGoogleAuthenticationUrlQueryOptions
  );

  const form = useForm<SignUpFormValues>({
    resolver: zodResolver(signUpSchema),
    defaultValues: {
      email: "",
      password: "",
    },
    mode: "onTouched",
  });

  const navigate = useNavigate();
  const { toast } = useToast();

  const [errorMessage, setErrorMessage] = useState<string | undefined>(
    undefined
  );

  const { mutate, isPending } = useMutation({
    mutationFn: signUp,
    onSuccess: (res) => {
      if (res.success && res.data) {
        toast({
          title: "Success",
          description:
            "Account created successfully, You can use this account to log in",
          variant: "success",
        });

        navigate({ to: "/sign-in" });

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
    googleUrl,
    navigate,
  };
}
