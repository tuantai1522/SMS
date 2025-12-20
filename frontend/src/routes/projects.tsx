import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/projects")({
  component: ProjectsPage,
});

function ProjectsPage() {
  return <div>Projects (coming soon)</div>;
}
