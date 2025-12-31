import { createFileRoute, Link } from "@tanstack/react-router";

import {
  Button,
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "../../features/shared/components/ui";

export const Route = createFileRoute("/_auth/sign-up")({
  component: SignUpPage,
});

function SignUpPage() {
  return (
    <div className="min-h-[calc(100vh-56px)] bg-white px-4 py-10 dark:bg-black">
      <div className="mx-auto w-full max-w-md">
        <Card>
          <CardHeader>
            <CardTitle>Create account</CardTitle>
            <CardDescription>
              This page is not implemented yet (UI-only).
            </CardDescription>
          </CardHeader>
          <CardContent>
            <div className="grid gap-3">
              <p className="text-sm text-black/70 dark:text-white/70">
                We’ll add the real sign-up flow later.
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
