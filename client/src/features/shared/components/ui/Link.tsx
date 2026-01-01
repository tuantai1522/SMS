import * as React from "react";
import { cn } from "../../../../lib/utils/cn";

type LinkVariant = "default" | "primary" | "secondary" | "accent";

type LinkProps = React.AnchorHTMLAttributes<HTMLAnchorElement> & {
  variant?: LinkVariant;
};

const BASE = "link";

const VARIANT: Record<LinkVariant, string> = {
  default: "",
  primary: "link-primary",
  secondary: "link-secondary",
  accent: "link-accent",
};

export const Link = React.forwardRef<HTMLAnchorElement, LinkProps>(
  ({ className, variant = "default", type, ...props }, ref) => {
    return (
      <a
        ref={ref}
        className={cn(BASE, VARIANT[variant], className)}
        {...props}
      />
    );
  }
);

Link.displayName = "Link";
