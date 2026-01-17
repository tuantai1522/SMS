import { createFileRoute, redirect } from "@tanstack/react-router";
import {
  getWorkspacesQueryOptions,
} from "../features/workspaces";
import { getMenuViewsByWorkspaceIdQueryOptions } from "../features/menuViews";
import { getMeQueryOptions } from "../features/users";

export const Route = createFileRoute("/")({
  beforeLoad: async ({ context }) => {
    const data = await context.queryClient.fetchQuery(getMeQueryOptions);

    if (data.success == false) {
      throw redirect({
        to: "/sign-in",
      });
    }

    const { data: workspaces } = await context.queryClient.ensureQueryData(
      getWorkspacesQueryOptions
    );

    if (workspaces && workspaces.length) {
      await context.queryClient.ensureQueryData(
        getMenuViewsByWorkspaceIdQueryOptions(workspaces[0].id)
      );

      throw redirect({
        to: "/workspaces/$workspaceId/home",
        params: { workspaceId: workspaces[0].id },
      });
    }
  },
});
