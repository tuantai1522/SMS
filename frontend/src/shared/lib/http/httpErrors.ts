import type { AxiosError } from "axios";

export function getHttpStatus(error: unknown): number | undefined {
  const axiosError = error as AxiosError | undefined;
  return axiosError?.response?.status;
}

export function isUnauthorizedOrForbidden(error: unknown): boolean {
  const status = getHttpStatus(error);
  return status === 401 || status === 403;
}
