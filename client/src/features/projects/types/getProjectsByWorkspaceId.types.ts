import type {
  OffsetPaginationRequest,
} from "../../shared/types/pagination.types";

export interface GetProjectsByWorkspaceIdResponse {
  id: string;
  name: string;
  emoji: string | null;
}

export interface GetProjectsByWorkspaceIdRequest extends OffsetPaginationRequest {
  workspaceId: string;
}
