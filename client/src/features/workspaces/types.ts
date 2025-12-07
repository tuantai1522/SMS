export type GetWorkspacesResponse = {
  id: string;
  name: string;
};

export type Workspace = {
  id: string;
  name: string;
};

export type GetMenuViewsResponse = {
  id: string;
  name: string;
  int: number;
  vid: string;
  icon: string;
};

export type MenuViewSidebarItem = GetMenuViewsResponse & {
  targetPath: string;
  isActive: boolean;
};
