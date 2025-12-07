import { useSuspenseQuery } from "@tanstack/react-query";
import { useLocation, useRouter } from "@tanstack/react-router";
import { getMenuViewsByWorkspaceIdOptions } from "../queries/getMenuViewsByWorkspaceIdOptions";
import type { MenuViewSidebarItem } from "../types";

export const useMenuViewSidebar = (workspaceId: string) => {
  const { data } = useSuspenseQuery(
    getMenuViewsByWorkspaceIdOptions(workspaceId)
  );

  const location = useLocation();
  const { buildLocation } = useRouter();

  const views: MenuViewSidebarItem[] =
    data.data?.map((view) => {
      const targetPath = buildLocation({
        to: view.vid,
        params: { workspaceId },
      }).pathname;

      const isActive =
        location.pathname === targetPath ||
        location.pathname.startsWith(targetPath + "/");

      return {
        ...view,
        targetPath,
        isActive,
      };
    }) ?? [];

  return {
    views,
  };
};
