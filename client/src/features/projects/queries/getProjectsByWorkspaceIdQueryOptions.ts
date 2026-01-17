import { queryOptions } from "@tanstack/react-query";

import { getProjectsByWorkspaceId } from "../apis";
import type { GetProjectsByWorkspaceIdRequest } from "../types";

export const getProjectsByWorkspaceIdQueryOptions = (workspaceId: string) =>
  queryOptions({
    queryKey: ["workspace-projects", workspaceId],
    queryFn: () => {
      const request: GetProjectsByWorkspaceIdRequest = {
        workspaceId,
        page: 1,
        pageSize: 50,
      };
      return getProjectsByWorkspaceId(request);
    },
    staleTime: 0,
  });
