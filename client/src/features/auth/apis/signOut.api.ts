import api from "../../shared/lib/axios";
import { API_PATHS } from "../../shared/utils/apiPaths";

export const signOut = async () => {
  const { data } = await api.get(API_PATHS.USERS.SIGN_OUT);
  return data;
};
