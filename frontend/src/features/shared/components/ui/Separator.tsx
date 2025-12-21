import * as React from "react";
import { cn } from "../../../../lib/utils/cn";

type SeparatorProps = React.HTMLAttributes<HTMLDivElement>;

export function Separator({ className, ...props }: SeparatorProps) {
  return (
    <div
      role="separator"
      className={cn("h-px w-full bg-black/10 dark:bg-white/10", className)}
      {...props}
    />
  );
}
