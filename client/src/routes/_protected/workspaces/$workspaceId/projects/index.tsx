import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/_protected/workspaces/$workspaceId/projects/")({
  component: ProjectPage,
});

function ProjectPage() {
  return <div>Hello "/_protected/projects"!</div>;
}
