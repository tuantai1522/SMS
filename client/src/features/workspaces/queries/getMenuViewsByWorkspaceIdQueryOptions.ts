import { queryOptions } from "@tanstack/react-query";

import { getMenuViewsByWorkspaceId } from "../apis";

export const getMenuViewsByWorkspaceIdQueryOptions = (
  workspaceId: string 
) =>
  queryOptions({
    queryKey: ["workspace-menu-views", workspaceId],
    queryFn: () => {
      return getMenuViewsByWorkspaceId(workspaceId);
    },
    staleTime: 0,
  });
