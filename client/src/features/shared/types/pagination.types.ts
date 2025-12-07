export type PaginationRequest<T> = {
  page: number;
  pageSize: number;
  filter?: T;
};

export type PaginationResponse<T> = {
  page: number;
  pageSize: number;
  totalCount: number;
  totalPages: number;
  hasNextPage: boolean;
  hasPreviousPage: boolean;
  items: T[];
};
