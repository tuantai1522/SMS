import { createRouter as createTanStackRouter } from "@tanstack/react-router";

import { routeTree } from "./routeTree.gen";
import { QueryClientProvider } from "@tanstack/react-query";
import { Suspense } from "react";
import { queryClient } from "./features/shared/lib/queryClient";

// Set up a Router instance
export function createRouter() {
  const router = createTanStackRouter({
    routeTree,
    context: {
      queryClient,
    },
    Wrap: function WrapComponent({ children }) {
      return (
        // Every component in routes can use React Query
        <QueryClientProvider client={queryClient}>
          {/* Todo: To add Spinner Suspense */}
          <Suspense fallback={<p>Loading....</p>}>{children}</Suspense>
        </QueryClientProvider>
      );
    },
  });

  return router;
}

declare module "@tanstack/react-router" {
  interface Register {
    router: ReturnType<typeof createRouter>;
  }
}
