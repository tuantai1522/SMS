export type CreateProjectRequest = {
  name: string;
  code: string;
  emoji?: string;
  description?: string;
  workspaceId: string;
};
