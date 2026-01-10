import { queryOptions } from "@tanstack/react-query";

import { getMenuViewsByWorkspaceId } from "../apis";

export const getMenuViewsByWorkspaceIdQueryOptions = (
  workspaceId: string | null | undefined
) =>
  queryOptions({
    queryKey: ["workspace-menu-views", workspaceId],
    queryFn: () => {
      if (!workspaceId) {
        throw new Error("workspaceId is required");
      }
      return getMenuViewsByWorkspaceId(workspaceId);
    },
    enabled: Boolean(workspaceId),
    staleTime: 0,
  });
