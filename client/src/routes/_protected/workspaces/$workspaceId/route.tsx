import { createFileRoute, Outlet } from "@tanstack/react-router";
import { SidebarView, Navbar, HomePanel } from "../../../../features/shared";
import { getProjectsByWorkspaceIdQueryOptions } from "../../../../features/projects";

// This will basically be workspace layout of application
export const Route = createFileRoute("/_protected/workspaces/$workspaceId")({
  component: WorkspacePage,
  loader: async ({ context, params }) => {
    await context.queryClient.ensureQueryData(
      getProjectsByWorkspaceIdQueryOptions(params.workspaceId),
    );
  },
});

function WorkspacePage() {
  const { workspaceId } = Route.useParams();

  return (
    <>
      <div className="drawer lg:drawer-open">
        <input id="my-drawer-4" type="checkbox" className="drawer-toggle" />
        <div className="drawer-content">
          <Navbar workspaceId={workspaceId} />
          <div className="flex min-h-[calc(100vh-4rem)]">
            <HomePanel workspaceId={workspaceId} />
            <div className="flex-1 p-4">
              <Outlet />
            </div>
          </div>
        </div>
        <div className="drawer-side is-drawer-close:overflow-visible">
          <div className="flex min-h-full">
            <SidebarView workspaceId={workspaceId} />
          </div>
        </div>
      </div>
    </>
  );
}
