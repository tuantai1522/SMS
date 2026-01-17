import { useSuspenseQuery } from "@tanstack/react-query";
import { getAvatarNames } from "../../shared";
import { getMeQueryOptions } from "../queries";

export function UserAvatar() {
  const { data } = useSuspenseQuery(getMeQueryOptions);

  const avatarUrl = data.data?.avatarUrl;
  const givenName = data.data?.givenName;

  return (
    <>
      <div
        tabIndex={0}
        role="button"
        className="btn btn-ghost btn-circle avatar"
      >
        {avatarUrl ? (
          <>
            <div className="w-10 rounded-full">
              <img alt={givenName} src={avatarUrl} />
            </div>
          </>
        ) : (
          <>
            <div className="avatar avatar-placeholder">
              <div className="bg-orange-500 text-neutral-content w-8 rounded-full">
                <span>{getAvatarNames(givenName)}</span>
              </div>
            </div>
          </>
        )}
      </div>
    </>
  );
}
