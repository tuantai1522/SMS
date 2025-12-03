import { createFileRoute, redirect } from "@tanstack/react-router";
import { meQueryOptions } from "../features/users/hooks/meQueryOptions";
import { getWorkspacesQueryOptions } from "../features/workspaces/hooks/getWorkspacesQueryOptions";

export const Route = createFileRoute("/")({
  beforeLoad: async ({ context }) => {
    const user = await context.queryClient.ensureQueryData(meQueryOptions);

    if (!user) {
      throw redirect({
        to: "/sign-in",
      });
    }

    const result = await context.queryClient.ensureQueryData(
      getWorkspacesQueryOptions
    );

    if (result?.data && result.data) {
      throw redirect({
        to: "/workspaces/$workspaceId/dashboard",
        params: { workspaceId: result.data[0].id },
      });
    }
  },
});
