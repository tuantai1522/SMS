import { createFileRoute, Outlet } from "@tanstack/react-router";
import { Sidebar } from "../../../../features/shared";

// This will basically be workspace layout of application
export const Route = createFileRoute("/_protected/workspaces/$workspaceId")({
  component: WorkspacePage,
});

function WorkspacePage() {
  const { workspaceId } = Route.useParams();

  return (
    <>
      <div className="drawer lg:drawer-open">
        <input id="my-drawer-4" type="checkbox" className="drawer-toggle" />
        <div className="drawer-content">
          <div className="p-4">
            <Outlet />
          </div>
        </div>
        <Sidebar workspaceId={workspaceId} />
      </div>
    </>
  );
}
