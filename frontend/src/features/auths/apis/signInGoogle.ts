import { api, API_PATHS, type BaseResult } from "../../shared";
import type {
  GoogleSignInRequest,
  GoogleSignInResponse,
} from "../types/googleSignIn.types";

export const signInGoogle = async (
  payload: GoogleSignInRequest
): Promise<BaseResult<GoogleSignInResponse>> => {
  try {
    const { data } = await api.post<BaseResult<GoogleSignInResponse>>(
      API_PATHS.AUTHS.GOOGLE_SIGN_IN,
      payload
    );
    return data;
  } catch (error: any) {
    return error.response.data as BaseResult<GoogleSignInResponse>;
  }
};
