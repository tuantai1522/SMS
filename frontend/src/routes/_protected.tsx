import { createFileRoute, redirect } from "@tanstack/react-router";
import { getMeQueryOptions } from "../features/users/hooks/getMeQueryOptions";

// This will protect route (check current user) so this user can go deeper into dashboard, projects, ...
export const Route = createFileRoute("/_protected")({
  beforeLoad: async ({ context }) => {
    const data = await context.queryClient.fetchQuery(getMeQueryOptions);

    if (data.success == false) {
      throw redirect({
        to: "/sign-in",
      });
    }
  },
});
