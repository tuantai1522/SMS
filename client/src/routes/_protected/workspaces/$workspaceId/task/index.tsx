import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute(
  "/_protected/workspaces/$workspaceId/task/"
)({
  component: DashboardPage,
});

function DashboardPage() {
  const { workspaceId } = Route.useParams();

  return <div>Hello "/_protected/task"! with {workspaceId}</div>;
}
