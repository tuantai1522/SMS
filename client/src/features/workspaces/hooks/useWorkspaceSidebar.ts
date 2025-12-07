import { useNavigate } from "@tanstack/react-router";
import { useEffect, useState } from "react";
import { useSuspenseQuery } from "@tanstack/react-query";
import { getWorkspacesQueryOptions } from "../queries/getWorkspacesQueryOptions";
import type { Workspace } from "../types";

export function useWorkspaceSidebar(workspaceId: string) {
  const navigate = useNavigate();

  const [activeWorkspace, setActiveWorkspace] = useState<Workspace>();

  const { data } = useSuspenseQuery(getWorkspacesQueryOptions);

  const onSelect = (workspace: Workspace) => {
    setActiveWorkspace(workspace);
    navigate({
      to: "/workspaces/$workspaceId/dashboard",
      params: { workspaceId: workspace.id },
    });
  };

  // First mount => select first workspace
  useEffect(() => {
    const workspaces = data.data;
    if (workspaces?.length) {
      const workspace = workspaceId
        ? workspaces.find((ws) => ws.id === workspaceId)
        : workspaces[0];

      if (workspace) {
        setActiveWorkspace(workspace);
        if (!workspaceId) {
          navigate({
            to: "/workspaces/$workspaceId/dashboard",
            params: { workspaceId: workspace.id },
          });
        }
      }
    }
  }, []);

  return {
    data,
    activeWorkspace,
    onSelect,
  };
}
