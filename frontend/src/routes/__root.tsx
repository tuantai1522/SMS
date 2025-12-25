import { Outlet, createRootRouteWithContext } from "@tanstack/react-router";

import { ThemeSwitcher } from "../features/shared/components/theme/ThemeSwitcher";
import type { QueryClient } from "@tanstack/react-query";

export interface RouterAppContext {
  queryClient: QueryClient;
}

export const Route = createRootRouteWithContext<RouterAppContext>()({
  component: () => (
    <>
      <div>
        <header>
          <nav className="flex items-center justify-between gap-4 p-3">
            <ThemeSwitcher />
          </nav>
        </header>

        <main>
          <Outlet />
        </main>
      </div>
    </>
  ),
});
