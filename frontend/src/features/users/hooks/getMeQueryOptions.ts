import { queryOptions } from "@tanstack/react-query";
import { getMe } from "../apis/getMe.api";

export const getMeQueryOptions = queryOptions({
  queryKey: ["me"],
  queryFn: getMe,
  staleTime: 0,
});
