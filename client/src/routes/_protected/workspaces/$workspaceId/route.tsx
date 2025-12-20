import { createFileRoute, Link, Outlet } from "@tanstack/react-router";
import {
  Sidebar,
  SidebarContent,
  SidebarFooter,
  SidebarGroup,
  SidebarGroupContent,
  SidebarHeader,
  SidebarInset,
  SidebarMenu,
  SidebarMenuButton,
  SidebarMenuItem,
  SidebarProvider,
} from "../../../../features/shared/components/ui/Sidebar";
import Logo from "../../../../features/shared/components/logo";
import { WorkspaceSidebar } from "../../../../features/workspaces/components/WorkspaceSidebar";
import { Separator } from "../../../../features/shared/components/ui/Seperator";
import { MenuViewSidebar } from "../../../../features/workspaces/components/MenuViewSidebar";
import { ProjectSidebar } from "../../../../features/workspaces/components/ProjectSidebar";
import { DialogHost } from "../../../../features/shared/components/dialog/DialogHost";
import { EllipsisIcon } from "lucide-react";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from "../../../../features/shared/components/ui/DropdownMenu";
import UserAvatar from "../../../../features/users/components/UserAvatar";
import { SignOutMenuItem } from "../../../../features/auth/components/SignOutMenuItem/SignOutMenuItem";

// This will basically be workspace layout of application
export const Route = createFileRoute("/_protected/workspaces/$workspaceId")({
  component: WorkspacePage,
});

function WorkspacePage() {
  const { workspaceId } = Route.useParams();

  return (
    <>
      <SidebarProvider>
        <div className="flex min-h-screen w-full">
          <div className="sticky top-0 h-screen shrink-0">
            <Sidebar collapsible="icon">
              <SidebarHeader className="!py-0 dark:bg-background">
                <div className="flex h-[50px] items-center justify-start w-full px-1">
                  <Logo url={`/workspace/${workspaceId}`} />
                  <Link
                    to="/workspaces/$workspaceId/dashboard"
                    params={{ workspaceId }}
                    className="hidden md:flex ml-2 items-center gap-2 self-center font-medium"
                  >
                    Team Sync.
                  </Link>
                </div>
              </SidebarHeader>

              <SidebarContent className="!mt-0 dark:bg-background">
                <SidebarGroup className="!py-0">
                  <SidebarGroupContent>
                    <WorkspaceSidebar workspaceId={workspaceId} />
                    <Separator />
                    <MenuViewSidebar workspaceId={workspaceId} />
                    <Separator />
                    <ProjectSidebar workspaceId={workspaceId} />
                  </SidebarGroupContent>
                </SidebarGroup>
              </SidebarContent>

              <SidebarFooter className="dark:bg-background">
                <SidebarMenu>
                  <SidebarMenuItem>
                    <DropdownMenu>
                      <DropdownMenuTrigger asChild>
                        <SidebarMenuButton
                          size="lg"
                          className="data-[state=open]:bg-sidebar-accent data-[state=open]:text-sidebar-accent-foreground"
                        >
                          <UserAvatar />
                          <EllipsisIcon className="ml-auto size-4" />
                        </SidebarMenuButton>
                      </DropdownMenuTrigger>
                      <DropdownMenuContent
                        className="w-[--radix-dropdown-menu-trigger-width] min-w-56 rounded-lg"
                        side={"top"}
                        align="start"
                        sideOffset={4}
                      >
                        <DropdownMenuSeparator />
                        <SignOutMenuItem />
                      </DropdownMenuContent>
                    </DropdownMenu>
                  </SidebarMenuItem>
                </SidebarMenu>
              </SidebarFooter>
            </Sidebar>
          </div>

          <SidebarInset className="overflow-x-hidden">
            <div className="w-full">
              <div className="px-3 lg:px-20 py-3">
                <Outlet />
              </div>
            </div>
          </SidebarInset>
        </div>
      </SidebarProvider>

      <DialogHost />
    </>
  );
}
