import { createFileRoute } from "@tanstack/react-router";
import SignInForm from "../../features/auth/components/SignInForm/SignInForm";

export const Route = createFileRoute("/_auth/sign-in")({
  component: SignInPage,
});

function SignInPage() {
  return <SignInForm />;
}
