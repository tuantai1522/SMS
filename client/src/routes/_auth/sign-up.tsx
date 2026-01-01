import { createFileRoute } from "@tanstack/react-router";
import { SignUpForm } from "../../features/auths";
import { getGoogleAuthenticationUrlQueryOptions } from "../../features/auths/queries/getGoogleAuthenticationUrlQueryOptions";

export const Route = createFileRoute("/_auth/sign-up")({
  component: SignUpPage,

  beforeLoad: async ({ context }) => {
    await context.queryClient.ensureQueryData(
      getGoogleAuthenticationUrlQueryOptions
    );
  },
});

function SignUpPage() {
  return <SignUpForm />;
}
