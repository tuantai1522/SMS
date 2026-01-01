import { Outlet, createRootRouteWithContext } from "@tanstack/react-router";

import type { QueryClient } from "@tanstack/react-query";
import { Toaster } from "../features/shared";

export interface RouterAppContext {
  queryClient: QueryClient;
}

export const Route = createRootRouteWithContext<RouterAppContext>()({
  component: () => (
    <>
      <div>
        <main>
          <Outlet />
          <Toaster />
        </main>
      </div>
    </>
  ),
});
