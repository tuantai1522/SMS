import { useMutation } from "@tanstack/react-query";
import type { AxiosError } from "axios";
import { signOut } from "../../apis/signOut.api";

export const useSignOut = () =>
  useMutation<void, AxiosError, void>({
    mutationFn: async () => {
      await signOut();
    },
  });
