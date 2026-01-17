import { useSuspenseQuery } from "@tanstack/react-query";
import { Link } from "@tanstack/react-router";
import { getMenuViewsByWorkspaceIdQueryOptions } from "../queries";
import { MaterialIcon } from "../../shared";

interface SidebarProps {
  workspaceId: string;
}

export function SidebarView({ workspaceId }: SidebarProps) {
  const { data } = useSuspenseQuery(
    getMenuViewsByWorkspaceIdQueryOptions(workspaceId),
  );

  return (
    <>
      <div className="flex min-h-full flex-col items-start bg-base-200 is-drawer-close:w-14 is-drawer-open:w-64">
        <ul className="menu w-full grow">
          {data.data?.map((view) => {
            const targetPath = `/workspaces/${workspaceId}/${view.vid}`;

            return (
              <li key={view.id}>
                <Link
                  to={targetPath}
                  data-tip={view.name}
                  className={
                    "is-drawer-close:tooltip is-drawer-close:tooltip-right flex items-center gap-2"
                  }
                  activeProps={{
                    className: "bg-primary/10 text-primary",
                  }}
                >
                  <MaterialIcon name={view.icon} size={20} weight="400" />
                  <span className="is-drawer-close:hidden">{view.name}</span>
                </Link>
              </li>
            );
          })}
        </ul>
      </div>
    </>
  );
}
