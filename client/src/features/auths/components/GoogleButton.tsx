import { useSuspenseQuery } from "@tanstack/react-query";
import { GoogleIcon } from "../../shared/components/icons";
import { getGoogleAuthenticationUrlQueryOptions } from "../queries/getGoogleAuthenticationUrlQueryOptions";

interface GoogleButtonProps {
  titlte: string;
}
export function GoogleButton({ titlte }: GoogleButtonProps) {
  const { data: googleUrl } = useSuspenseQuery(
    getGoogleAuthenticationUrlQueryOptions
  );

  return (
    <button
      onClick={() => (window.location.href = googleUrl.data!.url)}
      className="btn bg-white text-black border-[#e5e5e5]"
    >
      <GoogleIcon />
      {titlte}
    </button>
  );
}
