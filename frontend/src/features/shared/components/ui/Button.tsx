import * as React from "react";
import { cn } from "../../../../lib/utils/cn";

type ButtonVariant = "primary" | "secondary" | "ghost" | "muted";

type ButtonProps = React.ButtonHTMLAttributes<HTMLButtonElement> & {
  variant?: ButtonVariant;
};

const BASE =
  "inline-flex items-center justify-center gap-2 rounded-md px-4 py-2 text-sm font-medium transition-colors focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-offset-2 focus-visible:ring-offset-transparent disabled:pointer-events-none disabled:opacity-50";

const VARIANT: Record<ButtonVariant, string> = {
  primary:
    "bg-black text-white hover:bg-black/90 dark:bg-white dark:text-black dark:hover:bg-white/90",
  secondary:
    "bg-black/5 text-black hover:bg-black/10 dark:bg-white/10 dark:text-white dark:hover:bg-white/15",
  ghost:
    "bg-transparent text-black hover:bg-black/5 dark:text-white dark:hover:bg-white/10",
  muted:
    "bg-black/20 text-black hover:bg-black/25 dark:bg-white/20 dark:text-white dark:hover:bg-white/25",
};

export const Button = React.forwardRef<HTMLButtonElement, ButtonProps>(
  ({ className, variant = "primary", type, ...props }, ref) => {
    return (
      <button
        ref={ref}
        className={cn(BASE, VARIANT[variant], className)}
        type={type ?? "button"}
        {...props}
      />
    );
  }
);

Button.displayName = "Button";
