import { createFileRoute, Link } from "@tanstack/react-router";
import { googleSignInSchema } from "../../features/auths/schemas/googleSignIn.schema";
import { useAuthStore } from "../../features/auths/stores/auth.store";
import type { ApiError } from "../../features/shared";
import { useMutation } from "@tanstack/react-query";
import { useEffect, useRef, useState } from "react";
import { useNavigate, useRouter } from "@tanstack/react-router";
import { signInGoogle } from "../../features/auths/apis/signInGoogle";
import {
  Button,
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "../../features/shared/components/ui";
import Spinner from "../../features/shared/components/ui/Spinner";

export const Route = createFileRoute("/_auth/google-sign-in")({
  validateSearch: googleSignInSchema,

  component: GoogleSignInPage,
});

function GoogleSignInPage() {
  const { code } = Route.useSearch();

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

  return (
    <div className="min-h-[calc(100vh-56px)] bg-white px-4 py-12 dark:bg-black">
      <div className="mx-auto flex w-full max-w-md flex-col items-center justify-center gap-8">
        <Card className="w-full px-6 py-7">
          <CardHeader>
            <CardTitle>Google sign-in</CardTitle>
            <CardDescription>
              {errorMessage
                ? "We couldn’t complete your sign-in."
                : "Finishing authentication…"}
            </CardDescription>
          </CardHeader>

          <CardContent>
            {errorMessage ? (
              <div className="grid gap-4">
                <p className="text-sm font-medium text-red-600 dark:text-red-500">
                  {errorMessage}
                </p>

                <Link to="/sign-in" replace>
                  <Button className="w-full">Back to sign in</Button>
                </Link>
              </div>
            ) : (
              <div className="flex items-center justify-center gap-3 py-3">
                <Spinner />
                <p className="text-sm text-black/70 dark:text-white/70">
                  {isPending ? "Signing you in…" : "Redirecting…"}
                </p>
              </div>
            )}
          </CardContent>
        </Card>
      </div>
    </div>
  );
}
