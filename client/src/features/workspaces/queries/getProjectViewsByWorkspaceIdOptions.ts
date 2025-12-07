import { infiniteQueryOptions } from "@tanstack/react-query";
import { getProjectViewsByWorkspaceId } from "../apis/getProjectViewsByWorkspaceId.api";

export const getProjectViewsByWorkspaceIdOptions = (
  workspaceId: string,
  pageSize: number
) =>
  infiniteQueryOptions({
    queryKey: ["projects", workspaceId, pageSize],
    initialPageParam: 1,
    queryFn: ({ pageParam }) =>
      getProjectViewsByWorkspaceId(workspaceId, pageParam, pageSize),
    getNextPageParam: (lastPage) => {
      if (lastPage.data?.hasNextPage) {
        return lastPage.data.page + 1;
      }
    },
  });
