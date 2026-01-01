import * as React from "react";
import { cn } from "../../../../lib/utils/cn";

type ButtonVariant = "default" | "neutral" | "primary" | "secondary" | "accent";
type ButtonAppearance = "default" | "soft" | "active";

type ButtonProps = React.ButtonHTMLAttributes<HTMLButtonElement> & {
  variant?: ButtonVariant;
  appearance?: ButtonAppearance;
};

const BASE = "btn transition-opacity hover:opacity-85";

const VARIANT: Record<ButtonVariant, string> = {
  default: "",
  neutral: "btn-neutral",
  primary: "btn-primary",
  secondary: "btn-secondary",
  accent: "btn-accent",
};

const APPEARANCE: Record<ButtonAppearance, string> = {
  default: "",
  soft: "btn-soft",
  active: "btn-active",
};

export const Button = React.forwardRef<HTMLButtonElement, ButtonProps>(
  (
    { className, variant = "default", appearance = "default", type, ...props },
    ref
  ) => {
    return (
      <button
        ref={ref}
        className={cn(
          BASE,
          VARIANT[variant],
          APPEARANCE[appearance],
          className
        )}
        type={type ?? "button"}
        {...props}
      />
    );
  }
);

Button.displayName = "Button";
