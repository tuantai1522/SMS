import { createFileRoute } from "@tanstack/react-router";
import {
  getGoogleAuthenticationUrlQueryOptions,
  SignInForm,
} from "../../features/auths";

export const Route = createFileRoute("/_auth/sign-in")({
  component: SignInPage,

  beforeLoad: async ({ context }) => {
    await context.queryClient.ensureQueryData(
      getGoogleAuthenticationUrlQueryOptions,
    );
  },
});

function SignInPage() {
  return <SignInForm />;
}
