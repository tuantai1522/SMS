import { api, API_PATHS, type BaseResult, type OffsetPaginationResponse } from "../../shared";
import type {
  GetProjectsByWorkspaceIdRequest,
  GetProjectsByWorkspaceIdResponse,
} from "../types";

export const getProjectsByWorkspaceId = async (
  request: GetProjectsByWorkspaceIdRequest
): Promise<
  BaseResult<OffsetPaginationResponse<GetProjectsByWorkspaceIdResponse>>
> => {
  try {
    const { data } = await api.get<
      BaseResult<OffsetPaginationResponse<GetProjectsByWorkspaceIdResponse>>
    >(API_PATHS.WORKSPACES.GET_PROJECTS, {
      params: {
        workspaceId: request.workspaceId,
        Page: request.page,
        PageSize: request.pageSize,
      },
    });

    return data;
  } catch (error: any) {
    return error.response.data as BaseResult<
      OffsetPaginationResponse<GetProjectsByWorkspaceIdResponse>
    >;
  }
};
