import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import { RouterProvider } from "@tanstack/react-router";
import "./index.css";

import { createRouter } from "./router";
import { ThemeProvider } from "./features/shared";
import { TanStackRouterDevtools } from "@tanstack/react-router-devtools";

const router = createRouter();

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <ThemeProvider>
      <RouterProvider router={router} />
    </ThemeProvider>
    <TanStackRouterDevtools router={router} position="top-right" />
  </StrictMode>
);
