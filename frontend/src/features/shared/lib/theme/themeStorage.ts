import { isThemeMode, THEME_STORAGE_KEY, type ThemeMode } from "./themeTypes";

export function getStoredThemeMode(): ThemeMode | null {
  try {
    const value = localStorage.getItem(THEME_STORAGE_KEY);
    if (!value) return null;
    return isThemeMode(value) ? value : null;
  } catch {
    return null;
  }
}

export function setStoredThemeMode(themeMode: ThemeMode): void {
  try {
    localStorage.setItem(THEME_STORAGE_KEY, themeMode);
  } catch {
    // ignore
  }
}

export function clearStoredThemeMode(): void {
  try {
    localStorage.removeItem(THEME_STORAGE_KEY);
  } catch {
    // ignore
  }
}
