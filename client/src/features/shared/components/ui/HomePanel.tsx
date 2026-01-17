import { ProjectList } from "./ProjectList";

interface HomePanelProps {
  workspaceId: string;
}

export function HomePanel({ workspaceId }: HomePanelProps) {
  return (
    <div className="flex min-h-full w-64 flex-col bg-base-200">
      <div className="px-4 py-3">
        <h2 className="text-lg font-semibold">Home</h2>
      </div>
      <div className="flex-1 overflow-y-auto px-2">
        <ProjectList workspaceId={workspaceId} />
      </div>
    </div>
  );
}
