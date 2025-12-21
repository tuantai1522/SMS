import type { ThemeMode } from "./themeTypes";
import { resolveThemeMode } from "./themeResolution";

export function applyThemeToDocument(themeMode: ThemeMode): void {
  const root = document.documentElement;
  const resolved = resolveThemeMode(themeMode);

  root.dataset.theme = themeMode;
  root.classList.toggle("dark", resolved === "dark");
}
