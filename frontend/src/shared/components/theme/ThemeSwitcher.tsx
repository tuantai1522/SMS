import { useTheme } from "../../theme/ThemeContext";
import type { ThemeMode } from "../../theme/themeTypes";

const OPTIONS: Array<{ value: ThemeMode; label: string }> = [
  { value: "light", label: "Light" },
  { value: "dark", label: "Dark" },
  { value: "system", label: "System" },
];

export function ThemeSwitcher() {
  const { themeMode, setThemeMode } = useTheme();

  return (
    <label className="inline-flex items-center gap-2">
      <span className="text-sm">Theme</span>
      <select
        className="border rounded px-2 py-1 text-sm"
        value={themeMode}
        onChange={(e) => setThemeMode(e.target.value as ThemeMode)}
        aria-label="Theme"
      >
        {OPTIONS.map((opt) => (
          <option key={opt.value} value={opt.value}>
            {opt.label}
          </option>
        ))}
      </select>
    </label>
  );
}
