import { api, API_PATHS, type BaseResult } from "../../shared";
import type { GetMenuViewsByWorkspaceIdResponse } from "../types";

export const getMenuViewsByWorkspaceId = async (
  workspaceId: string
): Promise<BaseResult<GetMenuViewsByWorkspaceIdResponse[]>> => {
  try {
    const { data } = await api.get<
      BaseResult<GetMenuViewsByWorkspaceIdResponse[]>
    >(API_PATHS.WORKSPACES.GET_VIEWS, {
      params: {
        workspaceId,
      },
    });

    return data;
  } catch (error: any) {
    return error.response.data as BaseResult<
      GetMenuViewsByWorkspaceIdResponse[]
    >;
  }
};
