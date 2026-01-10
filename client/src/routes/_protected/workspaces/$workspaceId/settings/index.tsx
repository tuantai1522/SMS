import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute(
  "/_protected/workspaces/$workspaceId/settings/"
)({
  component: DashboardPage,
});

function DashboardPage() {
  const { workspaceId } = Route.useParams();

  return <div>Hello "/_protected/settings"! with {workspaceId}</div>;
}
