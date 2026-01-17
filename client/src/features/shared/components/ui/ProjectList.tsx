import { useSuspenseQuery } from "@tanstack/react-query";
import { getProjectsByWorkspaceIdQueryOptions } from "../../../projects";
import { PanelSection, type PanelItem } from "./PanelSection";

interface ProjectListProps {
  workspaceId: string;
}

export function ProjectList({ workspaceId }: ProjectListProps) {
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
