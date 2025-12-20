import { LogOut } from "lucide-react";
import { useRouter } from "@tanstack/react-router";
import { DropdownMenuItem } from "../../../shared/components/ui/DropdownMenu";
import { useAuthStore } from "../../stores/auth.store";
import { queryClient } from "../../../shared/lib/queryClient";
import { useMutation } from "@tanstack/react-query";
import { signOut } from "../../apis/signOut.api";

export function SignOutMenuItem() {
  const router = useRouter();

  const clearAccessToken = useAuthStore((s) => s.clearAccessToken);

  const signOutMutation = useMutation({
    mutationFn: signOut,
    async onSuccess() {
      clearAccessToken();

      await queryClient.cancelQueries({ queryKey: ["me"] });
      queryClient.removeQueries({ queryKey: ["me"] });

      await router.navigate({ to: "/sign-in" });
    },
    async onError() {
      clearAccessToken();
      await queryClient.cancelQueries({ queryKey: ["me"] });
      queryClient.removeQueries({ queryKey: ["me"] });
      await router.navigate({ to: "/sign-in" });
    },
  });

  const handleSignOut = async () => await signOutMutation.mutateAsync();
  
  return (
    <DropdownMenuItem
      disabled={signOutMutation.isPending}
      onSelect={handleSignOut}
    >
      <LogOut />
      Log out
    </DropdownMenuItem>
  );
}
