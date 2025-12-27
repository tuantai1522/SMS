import { createContext, useContext } from "react";

import type { UserTheme } from "./themeTypes";

type ThemeContextProps = {
  themeMode: UserTheme;
  setThemeMode: (theme: UserTheme) => void;
};

export const ThemeContext = createContext<ThemeContextProps | null>(null);

export function useTheme() {
  const value = useContext(ThemeContext);
  if (!value) {
    throw new Error("useTheme must be used within ThemeProvider");
  }
  return value;
}
