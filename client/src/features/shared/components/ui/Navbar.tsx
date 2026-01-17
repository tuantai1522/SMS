import { useSuspenseQuery } from "@tanstack/react-query";
import { getMeQueryOptions } from "../../../users/queries/getMeQueryOptions";
import { WorkspaceSwitcher } from "../../../workspaces";
import { getAvatarNames } from "../../utils/helpers";
import { Separator } from "./Separator";
import { Check } from "lucide-react";
import type { UserTheme } from "../../lib/theme/themeTypes";
import { useTheme } from "../../lib";

interface NavbarProps {
  workspaceId: string;
}

export const Navbar = ({ workspaceId }: NavbarProps) => {
  const { data } = useSuspenseQuery(getMeQueryOptions);

  return (
    <>
      <div className="navbar bg-base-100 shadow-sm">
        <div className="flex-1">
          <WorkspaceSwitcher workspaceId={workspaceId} />
        </div>
        <div className="flex gap-2">
          <div className="dropdown dropdown-end">
            <UserAvatar
              avatarUrl={data.data?.avatarUrl}
              givenName={data.data?.givenName}
            />

            <ul
              tabIndex={-1}
              className="menu menu-sm dropdown-content bg-base-100 rounded-box z-1 mt-3 w-52 p-2 shadow"
            >
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

// --------------------------------------- UserAvatar ---------------------------------------
interface UserAvatarProps {
  avatarUrl?: string | null;
  givenName?: string;
}

function UserAvatar({ avatarUrl, givenName }: UserAvatarProps) {
  return (
    <>
      <div
        tabIndex={0}
        role="button"
        className="btn btn-ghost btn-circle avatar"
      >
        {avatarUrl ? (
          <>
            <div className="w-10 rounded-full">
              <img alt={givenName} src={avatarUrl} />
            </div>
          </>
        ) : (
          <>
            <div className="avatar avatar-placeholder">
              <div className="bg-orange-500 text-neutral-content w-8 rounded-full">
                <span>{getAvatarNames(givenName)}</span>
              </div>
            </div>
          </>
        )}
      </div>
    </>
  );
}

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
