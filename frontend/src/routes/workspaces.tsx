import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/workspaces")({
  component: WorkspacesPage,
});

function WorkspacesPage() {
  return <div>Workspaces (coming soon)</div>;
}
