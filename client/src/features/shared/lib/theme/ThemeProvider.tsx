import { useEffect, useLayoutEffect, useState, type ReactNode } from "react";

import { ThemeContext } from "./ThemeContext";
import { UserThemeSchema, type UserTheme } from "./themeTypes";
import {
  getStoredUserTheme,
  handleThemeChange,
  setStoredTheme,
  setupPreferredListener,
} from "./themeStorage";
type ThemeProviderProps = {
  children: ReactNode;
};

export function ThemeProvider({ children }: ThemeProviderProps) {
  const [userTheme, setUserTheme] = useState<UserTheme>(getStoredUserTheme);

  useLayoutEffect(() => {
    handleThemeChange(userTheme);
  }, []);

  // This will handle theme related to "System" preference changes
  useEffect(() => {
    if (userTheme !== "system") return;
    return setupPreferredListener();
  }, [userTheme]);

  // const appTheme = userTheme === "system" ? getSystemTheme() : userTheme;

  const setTheme = (newUserTheme: UserTheme) => {
    const validatedTheme = UserThemeSchema.parse(newUserTheme);
    setUserTheme(validatedTheme);
    setStoredTheme(validatedTheme);
    handleThemeChange(validatedTheme);
  };

  return (
    <ThemeContext
      value={{
        themeMode: userTheme,
        setThemeMode: setTheme,
      }}
    >
      {children}
    </ThemeContext>
  );
}
