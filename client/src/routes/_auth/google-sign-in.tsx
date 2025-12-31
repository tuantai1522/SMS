import { createFileRoute } from "@tanstack/react-router";
import { googleSignInSchema } from "../../features/auths/schemas/googleSignIn.schema";

import { GoogleSignInForm } from "../../features/auths";

export const Route = createFileRoute("/_auth/google-sign-in")({
  validateSearch: googleSignInSchema,

  component: GoogleSignInPage,
});

function GoogleSignInPage() {
  const { code } = Route.useSearch();

  return <GoogleSignInForm code={code} />;
}
