import { createFileRoute } from "@tanstack/react-router";
import { SignInForm } from "../../features/auths";

export const Route = createFileRoute("/_auth/sign-in")({
  component: SignInPage,
});

function SignInPage() {
  return <SignInForm />;
}
