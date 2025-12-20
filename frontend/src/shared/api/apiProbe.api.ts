import { env } from "../config/env";
import { httpClient } from "../lib/http/httpClient";

export type ApiProbeResult = {
  openapi?: string;
  info?: {
    title?: string;
    version?: string;
  };
};

export async function apiProbe(): Promise<ApiProbeResult> {
  if (!env.apiBaseUrl) {
    throw new Error("VITE_API_BASE_URL is not set");
  }

  const response = await httpClient.get<ApiProbeResult>(env.apiProbePath);
  return response.data;
}
