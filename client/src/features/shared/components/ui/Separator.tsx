import * as React from "react";
import { cn } from "../../../../lib/utils/cn";

type SeparatorProps = React.HTMLAttributes<HTMLDivElement>;

export function Separator({ className, ...props }: SeparatorProps) {
  return <div role="divider" className={cn("divider", className)} {...props} />;
}
