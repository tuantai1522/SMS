import axios from "axios";
import { setupInterceptors } from "./interceptors";
import { BASE_URL } from "../../utils/apiPaths";

export const api = axios.create({
  baseURL: BASE_URL,
  withCredentials: true, // cookie refresh token
  timeout: 15000,
});

// attach interceptors
setupInterceptors(api);

export default api;
