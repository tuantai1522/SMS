import api from "../../shared/lib/axios";
import type { BaseResult } from "../../shared/types/baseResult.types";
import type { PaginationResponse } from "../../shared/types/pagination.types";
import { API_PATHS } from "../../shared/utils/apiPaths";
import type { GetProjectViewsByWorkspaceIdResponse } from "../types";

export const getProjectViewsByWorkspaceId = async (
  workspaceId: string,
  page: number,
  pageSize: number
): Promise<
  BaseResult<PaginationResponse<GetProjectViewsByWorkspaceIdResponse>>
> => {
  const res = await api.get(
    API_PATHS.WORKSPACES.GET_PROJECT_VIEWS_BY_WORKSPACE_ID,
    {
      params: {
        workspaceId,
        page,
        pageSize,
      },
    }
  );

  return res.data;
};
