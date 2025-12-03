import { createFileRoute, Outlet } from "@tanstack/react-router";

// This will basically be workspace layout of application
export const Route = createFileRoute("/_protected/workspaces/$workspaceId")({
  component: WorkspacePage,
});

function WorkspacePage() {
  const { workspaceId } = Route.useParams();

  return (
    <>
      {/* Render views or projects by workspace Id over there */}
      <div>
        Hello "/_protected/workspaces/$workspaceId/_layout"! with {workspaceId}
      </div>
      <Outlet />
    </>
  );
}
