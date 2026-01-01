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

export function handleChangeTheme(userTheme: UserTheme): void {
  if (!isBrowser) return;

  const validatedTheme = UserThemeSchema.parse(userTheme);

  if (validatedTheme === "system") {
    applyTheme(getSystemTheme());
  } else {
    applyTheme(validatedTheme);
  }
}

export function handleChangeSystemTheme(): () => void {
  if (!isBrowser) return () => {};

  const mediaQuery = window.matchMedia("(prefers-color-scheme: dark)");

  const handler = (e: MediaQueryListEvent) => {
    applyTheme(e.matches ? "dark" : "light");
  };

  mediaQuery.addEventListener("change", handler);

  return () => mediaQuery.removeEventListener("change", handler);
}

function applyTheme(theme: "light" | "dark") {
  const root = document.documentElement;
  root.classList.remove("light", "dark", "system");
  root.setAttribute("data-theme", theme);
}
