import { useSuspenseQuery } from "@tanstack/react-query";
import { GoogleIcon } from "../../shared";
import { getGoogleAuthenticationUrlQueryOptions } from "../queries";

interface GoogleButtonProps {
  title: string;
}
export function GoogleButton({ title }: GoogleButtonProps) {
  const { data: googleUrl } = useSuspenseQuery(
    getGoogleAuthenticationUrlQueryOptions
  );

  return (
    <button
      onClick={() => (window.location.href = googleUrl.data!.url)}
      className="btn bg-white text-black border-[#e5e5e5]"
    >
      <GoogleIcon />
      {title}
    </button>
  );
}
