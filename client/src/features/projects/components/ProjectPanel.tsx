import { useSuspenseQuery } from "@tanstack/react-query";
import { getProjectsByWorkspaceIdQueryOptions } from "..";
import { PanelSection, type PanelItem } from "../../shared/components/ui/PanelSection";

interface ProjectPanelProps {
  workspaceId: string;
}

export function ProjectPanel({ workspaceId }: ProjectPanelProps) {
  const { data } = useSuspenseQuery(
    getProjectsByWorkspaceIdQueryOptions(workspaceId)
  );

  const projectItems: PanelItem[] =
    data.data?.items.map((project) => ({
      id: project.id,
      name: project.name,
      emoji: project.emoji,
    })) || [];

  return (
    <PanelSection
      title="Projects"
      items={projectItems}
    />
  );
}
