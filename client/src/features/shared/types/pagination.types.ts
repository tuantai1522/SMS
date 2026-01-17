export interface OffsetPaginationRequest {
  page: number;
  pageSize: number;
}

export interface OffsetPaginationResponse<T> {
  items: T[];
  page: number;
  pageSize: number;
  totalCount: number;
  totalPages: number;
  hasNextPage: boolean;
  hasPreviousPage: boolean;
}