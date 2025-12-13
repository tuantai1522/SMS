import { z } from "zod";

const ProjectEnvSchema = z.object({
  VITE_DEFAULT_EMOJI: z.string(),
});

const parsed = ProjectEnvSchema.safeParse(import.meta.env);

if (!parsed.success) {
  console.error(
    "❌ Invalid Project Environment Variables:",
    parsed.error.cause
  );
  throw new Error("Missing or invalid project environment variables");
}

export const ProjectEnv = {
  DEFAULT_EMOJI: parsed.data.VITE_DEFAULT_EMOJI,
} as const;
