import type { QueryClient } from "@tanstack/react-query";
import { redirect } from "@tanstack/react-router";
import { getMeQueryOptions } from "../../users/queries/getMeQueryOptions";

export async function requireAuth(queryClient: QueryClient) {
  const data = await queryClient.fetchQuery(getMeQueryOptions);

  if (data.success === false) {
    throw redirect({ to: "/sign-in" });
  }

  return data;
}
