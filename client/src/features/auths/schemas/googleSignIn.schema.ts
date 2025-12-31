import { z } from "zod";

export const googleSignInSchema = z.object({
  code: z.string().min(1, "Code is required."),
});

export type GoogleSignInValues = z.infer<typeof googleSignInSchema>;
