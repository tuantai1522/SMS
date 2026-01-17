import { createFileRoute } from "@tanstack/react-router";
import { ProjectPanel } from "../../../../../features/projects";
import { Panel } from "../../../../../features/shared";

export const Route = createFileRoute(
  "/_protected/workspaces/$workspaceId/home/"
)({
  component: HomeComponent,
});

function HomeComponent() {
  const { workspaceId } = Route.useParams();

  return <>
    <div className="flex min-h-[calc(100vh-4rem)]">
      <Panel title="Home">
        <ProjectPanel workspaceId={workspaceId} />
      </Panel>
      <h1>Home</h1>
    </div>
  </>
}
