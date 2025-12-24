export type ApiErrorType =
  | 0 // Validation
  | 1 // NotFound
  | 2 // Conflict
  | 4 // Server
  | 5; // Failure

// Mirrors `SMS.Core.Common.Error` on the backend.
export type ApiError = {
  code: number;
  description: string;
  errorType: ApiErrorType;
};

// Mirrors `SMS.Core.Common.BaseResult<T>` on the backend.
export type BaseResult<T> = {
  success: boolean;
  data: T | null;
  errors: ApiError[] | null;
};

export function getFirstApiErrorDescription(
  errors: ApiError[] | null | undefined
): string | undefined {
  return errors?.[0]?.description;
}
