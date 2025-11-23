import { routeTree } from "./routeTree.gen";
import { createRouter } from "@tanstack/react-router";

// Set up a Router instance
export function createMyRouter() {
  const router = createRouter({
    routeTree,
  });

  return router;
}

// Register the router instance for type safety
declare module "@tanstack/react-router" {
  interface Register {
    router: typeof createMyRouter;
  }
}
