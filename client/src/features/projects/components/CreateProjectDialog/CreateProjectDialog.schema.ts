import * as z from "zod";

export const createProjectSchema = z.object({
  name: z
    .string()
    .min(1, "Project name is required")
    .max(255, "Project name is too long"),

  code: z
    .string()
    .min(1, "Project code is required")
    .max(50, "Project code is too long"),

  workspaceId: z.uuid({ error: "Invalid workspaceId" }),
  emoji: z.string(),
  description: z.string().trim().optional(),
});

export type CreateProjectSchema = z.infer<typeof createProjectSchema>;
