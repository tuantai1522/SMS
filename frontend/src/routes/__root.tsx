import { Outlet, createRootRoute } from "@tanstack/react-router";

import { ThemeSwitcher } from "../features/shared/components/theme/ThemeSwitcher";

export const Route = createRootRoute({
  component: RootLayout,
});

function RootLayout() {
  return (
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
  );
}
