import { api, API_PATHS, type BaseResult } from "../../shared";
import type { GetWorkspacesResponse } from "../types";

export const getWorkspaces = async (): Promise<
  BaseResult<GetWorkspacesResponse[]>
> => {
  try {
    const { data } = await api.get<BaseResult<GetWorkspacesResponse[]>>(
      API_PATHS.WORKSPACES.GET_WORKSPACES
    );

    return data;
  } catch (error: any) {
    return error.response.data as BaseResult<GetWorkspacesResponse[]>;
  }
};
