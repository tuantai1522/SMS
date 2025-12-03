import * as z from "zod";

export const signInFormSchema = z.object({
  email: z.email(),
  password: z
    .string()
    .min(8, "Password must be at least 8 characters")
    .max(128),
});

export type SignInFormSchema = z.infer<typeof signInFormSchema>;
