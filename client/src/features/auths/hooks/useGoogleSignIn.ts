import { useNavigate, useRouter } from "@tanstack/react-router";
import { useAuthStore } from "../stores/auth.store";
import { useEffect, useRef, useState } from "react";
import { useMutation } from "@tanstack/react-query";
import type { ApiError } from "../../shared";
import { signInGoogle } from "../apis/signInGoogle";

interface GoogleSignInProps {
  code: string;
}
export function useGoogleSignIn({ code }: GoogleSignInProps) {
  const router = useRouter();
  const navigate = useNavigate();
  const setToken = useAuthStore((s) => s.setAccessToken);

  const [errorMessage, setErrorMessage] = useState<string | undefined>(
    undefined
  );

  const hasAttemptedRef = useRef(false);

  const { mutate, isPending } = useMutation({
    mutationFn: signInGoogle,
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

      setErrorMessage(message || "Google sign-in failed.");
    },
    onError: () => {
      setErrorMessage("Something went wrong. Please try again.");
    },
  });

  useEffect(() => {
    if (hasAttemptedRef.current) return;
    hasAttemptedRef.current = true;
    mutate({ code });
  }, [code, mutate]);

  return {
    errorMessage,
    isPending,
  };
}
