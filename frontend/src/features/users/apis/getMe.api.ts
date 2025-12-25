import api from "../../shared/lib/axios";
import type { BaseResult } from "../../shared/types/baseResult";
import { API_PATHS } from "../../shared/utils/apiPaths";
import type { GetMeResponse } from "../types/getMe.types";

export const getMe = async (): Promise<BaseResult<GetMeResponse>> => {
  try {
    const res = await api.get<BaseResult<GetMeResponse>>(
      API_PATHS.USERS.GET_ME
    );
    return res.data;
  } catch (error: any) {
    return error.response.data as BaseResult<GetMeResponse>;
  }
};
