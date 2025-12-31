import { z } from "zod";

export const signInSchema = z.object({
  email: z.email("Enter a valid email address.").min(1, "Email is required."),
  password: z.string().min(1, "Password is required."),
  rememberMe: z.boolean().optional(),
});

export type SignInFormValues = z.infer<typeof signInSchema>;
