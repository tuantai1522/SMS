import { z } from "zod";

export const signUpSchema = z.object({
  email: z.email("Enter a valid email address."),
  password: z.string().min(8, "Password is required. Minimum 8 characters."),
});

export type SignUpFormValues = z.infer<typeof signUpSchema>;
