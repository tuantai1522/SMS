import { createFileRoute, redirect } from "@tanstack/react-router";
import { meQueryOptions } from "../features/users/hooks/meQueryOptions";

// This will protect route (check current user) so this user can go deeper into dashboard, projects, ...
export const Route = createFileRoute("/_protected")({
  beforeLoad: async ({ context }) => {
    const user = await context.queryClient.ensureQueryData(meQueryOptions);

    if (!user) {
      throw redirect({
        to: "/sign-in",
      });
    }

    return { user };
  },
});
