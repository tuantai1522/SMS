import { api, API_PATHS, type BaseResult } from "../../shared";
import type { GoogleAuthenticationUrlResponse } from "../types/googleAuthenticationUrl.types";

export const getGoogleAuthenticationUrl = async (): Promise<
  BaseResult<GoogleAuthenticationUrlResponse>
> => {
  try {
    const { data } = await api.get<BaseResult<GoogleAuthenticationUrlResponse>>(
      API_PATHS.AUTHS.GOOGLE_AUTHENTICATION_URL
    );
    return data;
  } catch (error: any) {
    return error.response.data as BaseResult<GoogleAuthenticationUrlResponse>;
  }
};
