import { queryOptions } from "@tanstack/react-query";

import { getWorkspaces } from "../apis";

export const getWorkspacesQueryOptions = queryOptions({
  queryKey: ["workspaces"],
  queryFn: getWorkspaces,
  staleTime: 0,
});
