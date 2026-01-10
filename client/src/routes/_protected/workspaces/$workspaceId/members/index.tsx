import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute(
  "/_protected/workspaces/$workspaceId/members/"
)({
  component: DashboardPage,
});

function DashboardPage() {
  const { workspaceId } = Route.useParams();

  return <div>Hello "/_protected/members"! with {workspaceId}</div>;
}
