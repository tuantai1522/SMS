import { type HTMLAttributes } from "react";
import { cn } from "../../../../lib/utils/cn";

type SpinnerProps = HTMLAttributes<HTMLDivElement>;

export const Spinner = ({ className, ...props }: SpinnerProps) => {
  return (
    <div className={cn("loading loading-spinner", className)} {...props} />
  );
};
