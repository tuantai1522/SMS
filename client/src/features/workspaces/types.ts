export type GetWorkspacesResponse = {
  id: string;
  name: string;
};

export type Workspace = {
  id: string;
  name: string;
};

export type GetMenuViewsByWorkspaceIdResponse = {
  id: string;
  name: string;
  int: number;
  vid: string;
  icon: string;
};

export type MenuViewSidebarItem = GetMenuViewsByWorkspaceIdResponse & {
  targetPath: string;
  isActive: boolean;
};

export type GetProjectViewsByWorkspaceIdResponse = {
  id: string;
  name: string;
  emoji?: string;
};
