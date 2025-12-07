import api from "../../shared/lib/axios";
import type { BaseResult } from "../../shared/types/baseResult.types";
import { API_PATHS } from "../../shared/utils/apiPaths";
import type { GetMenuViewsResponse } from "../types";

export const getMenuViewsByWorkspaceId = async (
  workspaceId: string
): Promise<BaseResult<GetMenuViewsResponse[]>> => {
  const res = await api.get(
    API_PATHS.WORKSPACES.GET_MENU_VIEWS_BY_WORKSPACE_ID,
    {
      params: { workspaceId },
    }
  );
  return res.data;
};
