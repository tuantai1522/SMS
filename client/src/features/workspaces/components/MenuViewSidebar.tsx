import { Link } from "@tanstack/react-router";
import {
  SidebarGroup,
  SidebarMenu,
  SidebarMenuButton,
  SidebarMenuItem,
} from "../../shared/components/ui/Sidebar";
import { MaterialIcon } from "../../shared/components/ui/MaterialIcon";
import { useMenuViewSidebar } from "../hooks/useMenuViewSidebar";

interface MenuViewSidebarProps {
  workspaceId: string;
}

export const MenuViewSidebar = ({ workspaceId }: MenuViewSidebarProps) => {
  const { views } = useMenuViewSidebar(workspaceId);

  return (
    <>
      <SidebarGroup>
        <SidebarMenu>
          {views.map((view) => (
            <SidebarMenuItem key={view.name}>
              <SidebarMenuButton isActive={view.isActive} asChild>
                <Link
                  to={view.vid}
                  params={{ workspaceId }}
                  className="!text-[15px]"
                >
                  <MaterialIcon name={view.icon} size={20} />
                  <span>{view.name}</span>
                </Link>
              </SidebarMenuButton>
            </SidebarMenuItem>
          ))}
        </SidebarMenu>
      </SidebarGroup>
    </>
  );
};
