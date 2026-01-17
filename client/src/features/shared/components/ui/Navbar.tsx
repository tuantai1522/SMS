import { Separator } from "./Separator";
import { Check } from "lucide-react";
import type { UserTheme } from "../../lib/theme/themeTypes";
import { useTheme } from "../../lib";
import { getMeQueryOptions, UserAvatar } from "../../../users";
import { useSuspenseQuery } from "@tanstack/react-query";
import { getAvatarNames } from "../../utils";
import { WorkspaceSwitcher } from "../../../workspaces";

interface NavbarProps {
  workspaceId: string;
}

export const Navbar = ({ workspaceId }: NavbarProps) => {
  return (
    <>
      <div className="navbar bg-base-100 shadow-sm">
        <div className="flex-1">
          <WorkspaceSwitcher workspaceId={workspaceId} />
        </div>
        <div className="flex gap-2">
          <div className="dropdown dropdown-end">
            <UserAvatar />

            <ul
              tabIndex={-1}
              className="menu menu-sm dropdown-content bg-base-100 rounded-box z-1 mt-3 w-52 p-2 shadow"
            >
              <li>
                <UserDataDropdown />
              </li>
              <Separator className="m-0" />
              <li>
                <a>Settings</a>
              </li>
              <Separator className="m-0" />
              <li>
                <ThemeSwitcher />
              </li>
              <Separator className="m-0" />
              <li>
                <a>Sign out</a>
              </li>
            </ul>
          </div>
        </div>
      </div>
    </>
  );
};

// --------------------------------------- Theme ---------------------------------------
const themeConfig: Record<UserTheme, { icon: string; label: string }> = {
  light: { icon: "☀️", label: "Light" },
  dark: { icon: "🌙", label: "Dark" },
  system: { icon: "💻", label: "System" },
};

function ThemeSwitcher() {
  const { themeMode, setThemeMode } = useTheme();

  return (
    <>
      <div className="dropdown dropdown-hover dropdown-left dropdown-end">
        <div tabIndex={0}>Theme</div>
        <ul
          tabIndex={-1}
          className="dropdown-content menu bg-base-100 rounded-box z-1 w-52 p-2 shadow-sm"
        >
          {Object.entries(themeConfig).map(([key, theme]) => {
            const isActive = themeMode === key;

            return (
              <li key={key} onClick={() => setThemeMode(key as UserTheme)}>
                <div className="flex items-center justify-between">
                  <span className="flex items-center gap-4">
                    <span>{theme.icon}</span>
                    <span>{theme.label}</span>
                  </span>

                  {isActive && <Check className="h-4 w-4 text-primary" />}
                </div>
              </li>
            );
          })}
        </ul>
      </div>
    </>
  );
}

function UserDataDropdown() {
  const { data } = useSuspenseQuery(getMeQueryOptions);
  const avatarUrl = data.data?.avatarUrl;
  const givenName = data.data?.givenName;

  return (
    <>
      <div className="flex items-center gap-3">
        {avatarUrl ? (
          <div className="flex h-6 w-6 items-center justify-center rounded-full bg-white">
            <img
              alt={givenName}
              src={avatarUrl}
              className="h-6 w-6 rounded-full object-cover"
            />
          </div>
        ) : (
          <div className="flex h-6 w-6 items-center justify-center rounded-full bg-white">
            <span className="text-base font-bold text-gray-800">
              {getAvatarNames(givenName)}
            </span>
          </div>
        )}
        <div className="flex flex-col">
          <span className="font-bold text-white">
            {givenName}
          </span>
        </div>
      </div>
    </>
  );
}