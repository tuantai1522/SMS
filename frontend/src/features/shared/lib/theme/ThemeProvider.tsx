import { useEffect, useMemo, useState } from "react";

import { applyThemeToDocument } from "./applyThemeToDocument";
import { getStoredThemeMode, setStoredThemeMode } from "./themeStorage";
import type { ThemeMode } from "./themeTypes";
import { ThemeContext } from "./ThemeContext";

export type ThemeProviderProps = {
  children: React.ReactNode;
};

const DEFAULT_THEME: ThemeMode = "light";

export function ThemeProvider({ children }: ThemeProviderProps) {
  const [themeMode, setThemeModeState] = useState<ThemeMode>(() => {
    return getStoredThemeMode() ?? DEFAULT_THEME;
  });

  useEffect(() => {
    applyThemeToDocument(themeMode);
    setStoredThemeMode(themeMode);
  }, [themeMode]);

  useEffect(() => {
    if (themeMode !== "system") return;

    const media = window.matchMedia?.("(prefers-color-scheme: dark)");
    if (!media) return;

    const handler = () => applyThemeToDocument("system");

    if (typeof media.addEventListener === "function") {
      media.addEventListener("change", handler);
      return () => media.removeEventListener("change", handler);
    }

    media.addListener(handler);
    return () => media.removeListener(handler);
  }, [themeMode]);

  const value = useMemo(
    () => ({
      themeMode,
      setThemeMode: setThemeModeState,
    }),
    [themeMode]
  );

  return (
    <ThemeContext.Provider value={value}>{children}</ThemeContext.Provider>
  );
}
