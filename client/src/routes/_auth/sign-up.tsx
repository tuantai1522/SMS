import { createFileRoute } from "@tanstack/react-router";
import { getGoogleAuthenticationUrlQueryOptions, SignUpForm } from "../../features/auths";

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
