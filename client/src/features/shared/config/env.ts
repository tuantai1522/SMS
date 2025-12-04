import { z } from "zod";

const SharedEnvSchema = z.object({
  VITE_API_URL: z.string().optional(),
  VITE_DEFAULT_PAGE: z.coerce.number().optional(),
  VITE_DEFAULT_PAGE_SIZE: z.coerce.number().optional(),
});

const parsed = SharedEnvSchema.safeParse(import.meta.env);

if (!parsed.success) {
  console.error(
    "❌ Invalid Payment Environment Variables:",
    parsed.error.cause
  );
  throw new Error("Missing or invalid shared environment variables");
}

// 4) Export object sạch, dễ dùng
export const SharedEnv = {
  API_URL: parsed.data.VITE_API_URL,
  PAGE: parsed.data.VITE_DEFAULT_PAGE,
  PAGE_SIZE: parsed.data.VITE_DEFAULT_PAGE_SIZE,
} as const;

console.log(SharedEnv);
