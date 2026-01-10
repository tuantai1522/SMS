import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute(
  "/_protected/workspaces/$workspaceId/chat/"
)({
  component: RouteComponent,
});

function RouteComponent() {
  const { workspaceId } = Route.useParams();

  return <div>Hello "/_protected/chat"! with {workspaceId}</div>;
}
