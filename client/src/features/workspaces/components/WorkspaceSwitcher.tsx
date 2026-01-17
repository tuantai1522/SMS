import { useSuspenseQuery } from "@tanstack/react-query";
import { useNavigate } from "@tanstack/react-router";
import { Check, ChevronDown } from "lucide-react";

import { getWorkspacesQueryOptions } from "../queries";
import type { GetWorkspacesResponse } from "../types";
import { CreateWorkspaceButton } from "./CreateWorkspaceButton";

// ----------------------------------------------- Workspace Switcher -----------------------------------------------
interface WorkspaceSwitcherProps {
  workspaceId: string;
}

export function WorkspaceSwitcher({
  workspaceId: activeWorkspaceId,
}: WorkspaceSwitcherProps) {
  const navigate = useNavigate();

  const { data } = useSuspenseQuery(getWorkspacesQueryOptions);

  const workspaces = data.data ?? [];

  const activeWorkspace = workspaces.find((w) => w.id === activeWorkspaceId);

  const handleSelectWorkspace = (workspaceId: string) => {
    navigate({
      to: "/workspaces/$workspaceId/home",
      params: { workspaceId },
    });
  };

  return (
    <div className="dropdown w-48">
      <div
        tabIndex={0}
        role="button"
        className="btn btn-ghost btn-sm w-full justify-between gap-2"
      >
        <span className="min-w-0 flex-1 truncate text-left font-bold">
          {activeWorkspace?.name}
        </span>
        <ChevronDown className="h-4 w-4 shrink-0" />
      </div>

      <div
        tabIndex={0}
        className="dropdown-content bg-base-100 rounded-box z-10 mt-1 w-full shadow-lg"
      >
        <div className="flex flex-col">
          <div className="mb-1 px-3 py-2 text-xs font-semibold text-base-content/60">
            Switch Workspace
          </div>

          <WorkspaceList
            workspaces={workspaces}
            activeWorkspaceId={activeWorkspaceId}
            onSelectWorkspace={handleSelectWorkspace}
          />

          <div className="divider my-1"></div>

          <div className="px-1 pb-1">
            <CreateWorkspaceButton />
          </div>
        </div>
      </div>
    </div>
  );
}

// ----------------------------------------------- Workspace list -----------------------------------------------
interface WorkspaceListProps {
  workspaces: GetWorkspacesResponse[];
  activeWorkspaceId: string;
  onSelectWorkspace: (id: string) => void;
}

function WorkspaceList({
  workspaces,
  activeWorkspaceId,
  onSelectWorkspace,
}: WorkspaceListProps) {
  return (
    <ul className="menu menu-sm w-full p-0 flex gap-1">
      {workspaces.map((workspace) => (
        <WorkspaceItem
          key={workspace.id}
          id={workspace.id}
          name={workspace.name}
          isActive={workspace.id === activeWorkspaceId}
          onSelect={onSelectWorkspace}
        />
      ))}
    </ul>
  );
}

// ----------------------------------------------- Workspace item -----------------------------------------------
interface WorkspaceItemProps {
  id: string;
  name: string;
  isActive: boolean;
  onSelect: (id: string) => void;
}

function WorkspaceItem({ id, name, isActive, onSelect }: WorkspaceItemProps) {
  const handleClick = () => {
    if (!isActive) {
      onSelect(id);
    }
  };

  return (
    <li className="w-full">
      <button
        type="button"
        onClick={handleClick}
        className={`flex w-full min-w-0 items-center justify-between gap-3 ${isActive ? "active" : ""}`}
      >
        <span className="min-w-0 flex-1 truncate text-left">{name}</span>
        {isActive && <Check className="h-4 w-4 shrink-0 text-primary" />}
      </button>
    </li>
  );
}
