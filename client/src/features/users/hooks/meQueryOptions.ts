import { queryOptions } from "@tanstack/react-query";
import { getMe } from "../apis/getMe.api";

export const meQueryOptions = queryOptions({
  queryKey: ["me"],
  queryFn: getMe,
  staleTime: 0,
});
