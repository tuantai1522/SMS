import { Plus } from "lucide-react";

export function CreateWorkspaceButton() {
  const handleClick = () => {
    // No-op in v1
  };

  return (
    <button
      type="button"
      onClick={handleClick}
      className="btn btn-ghost btn-sm w-full justify-start gap-2"
    >
      <Plus className="h-4 w-4" />
      <span>Create workspace</span>
    </button>
  );
}
