import * as React from "react";
import { cn } from "../../../../lib/utils/cn";

type DivProps = React.HTMLAttributes<HTMLDivElement>;

export function Card({ className, ...props }: DivProps) {
  return (
    <div
      className={cn(
        "rounded-xl border border-black/10 bg-white/70 p-6 backdrop-blur dark:border-white/15 dark:bg-black/60",
        className
      )}
      {...props}
    />
  );
}

export function CardHeader({ className, ...props }: DivProps) {
  return <div className={cn("mb-4", className)} {...props} />;
}

export function CardTitle({ className, ...props }: DivProps) {
  return (
    <div
      className={cn(
        "text-xl font-semibold leading-tight text-black dark:text-white",
        className
      )}
      {...props}
    />
  );
}

export function CardDescription({ className, ...props }: DivProps) {
  return (
    <div
      className={cn("text-sm text-black/60 dark:text-white/60", className)}
      {...props}
    />
  );
}

export function CardContent({ className, ...props }: DivProps) {
  return <div className={cn("", className)} {...props} />;
}

export function CardFooter({ className, ...props }: DivProps) {
  return <div className={cn("mt-4", className)} {...props} />;
}
