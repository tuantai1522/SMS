import axios from "axios";
import { setupInterceptors } from "./interceptors";
import { Config } from "../../config";

export const api = axios.create({
  baseURL: Config.shared.API_URL,
  withCredentials: true, // cookie refresh token
  timeout: 15000,
});

// attach interceptors
setupInterceptors(api);

export default api;
