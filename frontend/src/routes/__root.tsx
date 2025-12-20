import { Link, Outlet, createRootRoute } from "@tanstack/react-router";

import { ThemeSwitcher } from "../shared/components/theme/ThemeSwitcher";

export const Route = createRootRoute({
  component: RootLayout,
});

function RootLayout() {
  return (
    <div>
      <header>
        <nav className="flex items-center justify-between gap-4 p-3">
          <div className="flex items-center gap-2">
            <Link to="/" activeOptions={{ exact: true }}>
              Home
            </Link>
            <span aria-hidden>|</span>
            <Link to="/auth">Auth</Link>
            <span aria-hidden>|</span>
            <Link to="/projects">Projects</Link>
            <span aria-hidden>|</span>
            <Link to="/workspaces">Workspaces</Link>
          </div>

          <ThemeSwitcher />
        </nav>
      </header>

      <main>
        <Outlet />
      </main>
    </div>
  );
}
