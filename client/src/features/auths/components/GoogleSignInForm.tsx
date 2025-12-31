import { Link } from "@tanstack/react-router";
import {
  Button,
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
  Spinner,
} from "../../shared";
import { useGoogleSignIn } from "../hooks/useGoogleSignIn";

interface GoogleSignInFormProps {
  code: string;
}
export function GoogleSignInForm({ code }: GoogleSignInFormProps) {
  const { errorMessage, isPending } = useGoogleSignIn({ code });
  
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
