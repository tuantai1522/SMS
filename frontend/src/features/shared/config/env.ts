import { z } from "zod";

const SharedEnvSchema = z.object({
  VITE_API_URL: z.string(),
});

const parsed = SharedEnvSchema.safeParse(import.meta.env);

if (!parsed.success) {
  console.error("❌ Invalid shared Environment Variables:", parsed.error.cause);
  throw new Error("Missing or invalid shared environment variables");
}

// 4) Export object sạch, dễ dùng
export const SharedEnv = {
  API_URL: parsed.data.VITE_API_URL,
} as const;
