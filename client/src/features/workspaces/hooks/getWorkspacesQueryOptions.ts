import { queryOptions } from "@tanstack/react-query";
import { getWorkspaces } from "../apis/getWorkspaces.api";

export const getWorkspacesQueryOptions = queryOptions({
  queryKey: ["workspaces"],
  queryFn: getWorkspaces,
  staleTime: 0,
});
