import { queryOptions } from "@tanstack/react-query";
import { getGoogleAuthenticationUrl } from "../apis/getGoogleAuthenticationUrl.api";

export const getGoogleAuthenticationUrlQueryOptions = queryOptions({
  queryKey: ["google-url"],
  queryFn: getGoogleAuthenticationUrl,
  staleTime: 0,
});
