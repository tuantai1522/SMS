import { QueryCache, QueryClient } from "@tanstack/react-query";

import { isUnauthorizedOrForbidden } from "./http/httpErrors";

export function createAppQueryClient() {
  return new QueryClient({
    defaultOptions: {
      queries: {
        retry: 1,
        refetchOnWindowFocus: false,
      },
      mutations: {
        retry: 0,
      },
    },
    queryCache: new QueryCache({
      onError: (error) => {
        if (isUnauthorizedOrForbidden(error)) {
          console.warn("Unauthorized/forbidden query error", error);
          return;
        }

        console.warn("Query error", error);
      },
    }),
  });
}

export const queryClient = createAppQueryClient();
