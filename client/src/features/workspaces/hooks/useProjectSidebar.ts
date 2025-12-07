import { useSuspenseInfiniteQuery } from "@tanstack/react-query";
import { getProjectViewsByWorkspaceIdOptions } from "../queries/getProjectViewsByWorkspaceIdOptions";
import { Config } from "../../shared/config";

export function useProjectSidebar(workspaceId: string) {
  const pageSize = Config.shared.PAGE_SIZE;

  const query = useSuspenseInfiniteQuery(
    getProjectViewsByWorkspaceIdOptions(workspaceId, pageSize)
  );

  const projects = query.data?.pages?.flatMap((p) => p.data?.items ?? []) ?? [];

  return {
    ...query,
    pageSize,
    projects,
  };
}
