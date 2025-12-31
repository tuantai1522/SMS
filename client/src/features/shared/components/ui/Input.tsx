import { forwardRef, type ComponentProps } from "react";
import { cn } from "../../../../lib/utils/cn";

export const Input = forwardRef<HTMLInputElement, ComponentProps<"input">>(
  ({ className, type, ...props }, ref) => {
    return (
      <>
        <input
          type={type}
          className={cn(
            "w-full rounded-md border border-black/15 bg-transparent px-3 py-2 text-sm text-black placeholder:text-black/50 outline-none transition focus-visible:border-black/30 focus-visible:ring-2 focus-visible:ring-black/15 dark:border-white/15 dark:text-white dark:placeholder:text-white/40 dark:focus-visible:border-white/30 dark:focus-visible:ring-white/15",
            className
          )}
          ref={ref}
          {...props}
        />
      </>
    );
  }
);

Input.displayName = "Input";
