import type { UserTheme } from "../../lib/theme/themeTypes";
import { useTheme } from "../../lib/theme/ThemeContext";

const themeConfig: Record<UserTheme, { icon: string; label: string }> = {
  light: { icon: "☀️", label: "Light" },
  dark: { icon: "🌙", label: "Dark" },
  system: { icon: "💻", label: "System" },
};

export function ThemeSwitcher() {
  const { themeMode, setThemeMode } = useTheme();

  return (
    <label className="inline-flex items-center gap-2">
      <select
        className="border rounded px-2 py-1 text-sm"
        value={themeMode}
        onChange={(e) => setThemeMode(e.target.value as UserTheme)}
        aria-label="Theme"
      >
        {Object.entries(themeConfig).map(([key, theme]) => (
          <option key={key} value={key}>
            <span className="not-system:light:inline hidden">
              {theme.label}
              <span className="ml-1">{theme.icon}</span>
            </span>
          </option>
        ))}
      </select>
    </label>
  );
}
