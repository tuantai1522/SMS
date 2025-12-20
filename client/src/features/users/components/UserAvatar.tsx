import { useSuspenseQuery } from "@tanstack/react-query";
import { meQueryOptions } from "../hooks/meQueryOptions";
import { Avatar, AvatarFallback } from "../../shared/components/ui/Avatar";

export default function UserAvatar() {
  const { data: user } = useSuspenseQuery(meQueryOptions);

  return (
    <>
      <Avatar className="h-8 w-8 rounded-full">
        {/* <AvatarImage src={user?.data. || ""} /> */}
        <AvatarFallback className="rounded-full border border-gray-500">
          {user?.data?.nickName?.split(" ")?.[0]?.charAt(0)}
          {user?.data?.nickName.split(" ")?.[1]?.charAt(0)}
        </AvatarFallback>
      </Avatar>
      <div className="grid flex-1 text-left text-sm leading-tight">
        <span className="truncate font-semibold">{user?.data?.nickName}</span>
        <span className="truncate text-xs">{user?.data?.email}</span>
      </div>
    </>
  );
}
