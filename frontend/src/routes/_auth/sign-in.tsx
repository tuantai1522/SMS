import { createFileRoute } from "@tanstack/react-router";
import { SignInForm } from "../../features/auths";
import { getGoogleAuthenticationUrlQueryOptions } from "../../features/auths/queries/getGoogleAuthenticationUrlQueryOptions";

export const Route = createFileRoute("/_auth/sign-in")({
  component: SignInPage,

  beforeLoad: async ({ context }) => {
    await context.queryClient.ensureQueryData(
      getGoogleAuthenticationUrlQueryOptions
    );
  },
});

function SignInPage() {
  return <SignInForm />;
}
