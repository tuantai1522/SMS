import api from "../../shared/lib/axios";
import type { BaseResult } from "../../shared/types/baseResult";
import { API_PATHS } from "../../shared/utils/apiPaths";
import type { SignInRequest, SignInResponse } from "../types/signIn.types";

export const signIn = async (
  payload: SignInRequest
): Promise<BaseResult<SignInResponse>> => {
  const { data } = await api.post<BaseResult<SignInResponse>>(
    API_PATHS.USERS.SIGN_IN,
    payload
  );
  return data;
};
