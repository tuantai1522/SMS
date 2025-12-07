import { queryOptions } from "@tanstack/react-query";
import { getMenuViewsByWorkspaceId } from "../apis/getMenuViews.api";

export const getMenuViewsByWorkspaceIdOptions = (workspaceId: string) =>
  queryOptions({
    queryKey: ["views", workspaceId],
    queryFn: () => getMenuViewsByWorkspaceId(workspaceId),
    staleTime: 0,
  });
