import type { ThemeMode } from "./themeTypes";

export function getSystemPrefersDark(): boolean {
  return window.matchMedia?.("(prefers-color-scheme: dark)")?.matches ?? false;
}

export function resolveThemeMode(themeMode: ThemeMode): "light" | "dark" {
  if (themeMode === "system") {
    return getSystemPrefersDark() ? "dark" : "light";
  }
  return themeMode;
}
