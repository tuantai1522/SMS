import type { AxiosInstance } from "axios";
import { useAuthStore } from "../../../auths/stores/auth.store";
import { API_PATHS } from "../../utils/apiPaths";

export function setupInterceptors(api: AxiosInstance) {
  // REQUEST: attach token
  api.interceptors.request.use((config) => {
    const token = useAuthStore.getState().accessToken;
    if (token && !config.headers.Authorization) {
      config.headers.Authorization = `Bearer ${token}`;
    }

    return config;
  });

  // RESPONSE: auto refresh
  api.interceptors.response.use(
    (res) => res,
    async (error) => {
      const original = error.config;

      // chưa retry bao giờ
      if (error.response?.status === 401 && !original._retry) {
        original._retry = true;

        try {
          const refreshToken = await api.get(API_PATHS.AUTHS.REFRESH_TOKEN);
          const newToken = refreshToken.data.data.token;

          useAuthStore.getState().setAccessToken(newToken);

          // Update header & retry
          original.headers.Authorization = `Bearer ${newToken}`;
          return api(original);
        } catch {
          useAuthStore.getState().clearAccessToken();
        }
      }

      return Promise.reject(error);
    }
  );
}
