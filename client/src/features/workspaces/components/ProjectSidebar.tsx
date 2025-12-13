import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from "../../shared/components/ui/DropdownMenu";
import {
  SidebarGroup,
  SidebarGroupLabel,
  SidebarMenu,
  SidebarMenuAction,
  SidebarMenuButton,
  SidebarMenuItem,
} from "../../shared/components/ui/Sidebar";
import { Link } from "@tanstack/react-router";
import { ArrowRight, Folder, MoreHorizontal, Plus } from "lucide-react";
import { useProjectSidebar } from "../hooks/useProjectSidebar";
import { useDialog } from "../../shared/lib/dialog/useDialog";
import { Button } from "../../shared/components/ui/Button";

interface ProjectSidebarProps {
  workspaceId: string;
}

export const ProjectSidebar = ({ workspaceId }: ProjectSidebarProps) => {
  const { projects, fetchNextPage, hasNextPage, isFetchingNextPage } =
    useProjectSidebar(workspaceId);

  const { openDialog } = useDialog();

  return (
    <>
      <SidebarGroup className="group-data-[collapsible=icon]:hidden">
        <SidebarGroupLabel className="w-full justify-between pr-0">
          <span>Projects</span>

          <button
            onClick={() => openDialog("project.create", { workspaceId })}
            type="button"
            className="flex size-5 items-center justify-center rounded-full border"
          >
            <Plus className="size-3.5" />
          </button>
        </SidebarGroupLabel>
        <SidebarMenu className="h-[320px] scrollbar overflow-y-auto pb-2">
          {projects.length === 0 ? (
            <div className="pl-3">
              <p className="text-xs text-muted-foreground">
                There is no projects in this Workspace yet. Projects you create
                will show up here.
              </p>
              <Button
                variant="link"
                type="button"
                className="h-0 p-0 text-[13px] underline font-semibold mt-4"
                onClick={() => openDialog("project.create", { workspaceId })}
              >
                Create a project
                <ArrowRight />
              </Button>
            </div>
          ) : (
            projects.map((item) => {
              return (
                <SidebarMenuItem key={item.id}>
                  <SidebarMenuButton asChild>
                    <Link to={"."}>
                      {item.emoji}
                      <span>{item.name}</span>
                    </Link>
                  </SidebarMenuButton>

                  <DropdownMenu>
                    <DropdownMenuTrigger asChild>
                      <SidebarMenuAction showOnHover>
                        <MoreHorizontal />
                        <span className="sr-only">More</span>
                      </SidebarMenuAction>
                    </DropdownMenuTrigger>

                    <DropdownMenuContent className="w-48 rounded-lg">
                      <DropdownMenuItem
                      // onClick={() => navigate({ to: projectUrl })}
                      >
                        <Folder className="text-muted-foreground" />
                        <span>View Project</span>
                      </DropdownMenuItem>

                      <DropdownMenuSeparator />
                    </DropdownMenuContent>
                  </DropdownMenu>
                </SidebarMenuItem>
              );
            })
          )}

          {hasNextPage && (
            <SidebarMenuItem>
              <SidebarMenuButton
                className="text-sidebar-foreground/70"
                disabled={isFetchingNextPage}
                onClick={() => fetchNextPage()}
              >
                <MoreHorizontal className="text-sidebar-foreground/70" />
                <span>{isFetchingNextPage ? "Loading..." : "More"}</span>
              </SidebarMenuButton>
            </SidebarMenuItem>
          )}
        </SidebarMenu>
      </SidebarGroup>
    </>
  );
};
