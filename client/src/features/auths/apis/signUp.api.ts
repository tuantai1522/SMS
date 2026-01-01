import { api, API_PATHS, type BaseResult } from "../../shared";
import type { SignUpRequest } from "../types/signUp.types";

export const signUp = async (
  payload: SignUpRequest
): Promise<BaseResult<string>> => {
  try {
    const { data } = await api.post<BaseResult<string>>(
      API_PATHS.AUTHS.SIGN_UP,
      payload
    );
    return data;
  } catch (error: any) {
    return error.response.data as BaseResult<string>;
  }
};
