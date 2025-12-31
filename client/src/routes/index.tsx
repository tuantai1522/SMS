import { createFileRoute, redirect } from "@tanstack/react-router";
import { getMeQueryOptions } from "../features/users/queries/getMeQueryOptions";

export const Route = createFileRoute("/")({
  beforeLoad: async ({ context }) => {
    const data = await context.queryClient.fetchQuery(getMeQueryOptions);

    if (data.success == false) {
      throw redirect({
        to: "/sign-in",
      });
    }
  },
});
