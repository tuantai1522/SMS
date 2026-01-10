import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute(
  "/_protected/workspaces/$workspaceId/dashboard/"
)({
  component: DashboardPage,
});

function DashboardPage() {
  const { workspaceId } = Route.useParams();

  return <div>Hello "/_protected/dashboard"! with {workspaceId}</div>;
}
