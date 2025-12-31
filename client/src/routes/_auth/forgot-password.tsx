import { createFileRoute, Link } from "@tanstack/react-router";

import {
  Button,
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "../../features/shared/components/ui";

export const Route = createFileRoute("/_auth/forgot-password")({
  component: ForgotPasswordPage,
});

function ForgotPasswordPage() {
  return (
    <div className="min-h-[calc(100vh-56px)] bg-white px-4 py-10 dark:bg-black">
      <div className="mx-auto w-full max-w-md">
        <Card>
          <CardHeader>
            <CardTitle>Forgot password</CardTitle>
            <CardDescription>
              This page is not implemented yet (UI-only).
            </CardDescription>
          </CardHeader>

          <CardContent>
            <div className="grid gap-3">
              <p className="text-sm text-black/70 dark:text-white/70">
                Well add the real password reset flow later.
              </p>

              <Link to="/sign-in">
                <Button className="w-full">Back to sign in</Button>
              </Link>
            </div>
          </CardContent>
        </Card>
      </div>
    </div>
  );
}
