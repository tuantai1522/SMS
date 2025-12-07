import api from "../../shared/lib/axios";
import type { BaseResult } from "../../shared/types/baseResult.types";
import { API_PATHS } from "../../shared/utils/apiPaths";
import type { GetWorkspacesResponse } from "../types";

export const getWorkspaces = async (): Promise<
  BaseResult<GetWorkspacesResponse[]>
> => {
  const res = await api.get<BaseResult<GetWorkspacesResponse[]>>(
    API_PATHS.WORKSPACES.GET_WORKSPACES
  );
  return res.data;
};
