import { z } from "zod";

const UserThemeSchema = z.enum(["light", "dark", "system"]).catch("system");
const AppThemeSchema = z.enum(["light", "dark"]).catch("light");

export type UserTheme = z.infer<typeof UserThemeSchema>;
export type AppTheme = z.infer<typeof AppThemeSchema>;

export const THEME_STORAGE_KEY = "sms.theme";

const isBrowser = typeof window !== "undefined";

export function getStoredUserTheme(): UserTheme {
  if (!isBrowser) return "system";

  const stored = window.localStorage.getItem(THEME_STORAGE_KEY);
  return UserThemeSchema.parse(stored);
}

export function setStoredTheme(theme: UserTheme): void {
  if (!isBrowser) return;

  const validatedTheme = UserThemeSchema.parse(theme);
  window.localStorage.setItem(THEME_STORAGE_KEY, validatedTheme);
}

export function getSystemTheme(): AppTheme {
  if (!isBrowser) return "light";

  return window.matchMedia("(prefers-color-scheme: dark)").matches
    ? "dark"
    : "light";
}

export function handleThemeChange(userTheme: UserTheme): void {
  if (!isBrowser) return;

  const validatedTheme = UserThemeSchema.parse(userTheme);

  const root = document.documentElement;
  root.classList.remove("light", "dark", "system");

  if (validatedTheme === "system") {
    const systemTheme = getSystemTheme();
    root.classList.add(systemTheme, "system");
  } else {
    root.classList.add(validatedTheme);
  }
}

export function setupPreferredListener(): () => void {
  if (!isBrowser) return () => {};

  const mediaQuery = window.matchMedia("(prefers-color-scheme: dark)");
  const handler = () => handleThemeChange("system");
  mediaQuery.addEventListener("change", handler);
  return () => mediaQuery.removeEventListener("change", handler);
}
