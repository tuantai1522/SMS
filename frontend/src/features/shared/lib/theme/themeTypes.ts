export type ThemeMode = "light" | "dark" | "system";

export const THEME_STORAGE_KEY = "sms.theme";

export function isThemeMode(value: unknown): value is ThemeMode {
  return value === "light" || value === "dark" || value === "system";
}
