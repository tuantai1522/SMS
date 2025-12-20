export const env = {
  apiBaseUrl: import.meta.env.VITE_API_BASE_URL as string | undefined,
  apiProbePath:
    (import.meta.env.VITE_API_PROBE_PATH as string | undefined) ??
    "/swagger/v1/swagger.json",
} as const;
