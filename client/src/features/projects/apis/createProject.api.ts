import api from "../../shared/lib/axios";
import type { BaseResult } from "../../shared/types/baseResult.types";
import { API_PATHS } from "../../shared/utils/apiPaths";
import type { CreateProjectRequest } from "../types/createProject.types";

export const createProject = async (
  payload: CreateProjectRequest
): Promise<BaseResult<string>> => {
  const { data } = await api.post<BaseResult<string>>(
    API_PATHS.PROJECTS.CREATE_PROJECT,
    payload
  );
  return data;
};
