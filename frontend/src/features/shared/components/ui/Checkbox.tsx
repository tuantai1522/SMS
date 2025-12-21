import * as React from "react";
import { cn } from "../../../../lib/utils/cn";

type CheckboxProps = Omit<
  React.InputHTMLAttributes<HTMLInputElement>,
  "type"
> & {
  label?: React.ReactNode;
  errorMessage?: React.ReactNode;
  errorId?: string;
  containerClassName?: string;
};

export const Checkbox = React.forwardRef<HTMLInputElement, CheckboxProps>(
  (
    {
      className,
      containerClassName,
      label,
      errorMessage,
      errorId,
      id,
      "aria-describedby": ariaDescribedBy,
      "aria-invalid": ariaInvalid,
      ...props
    },
    ref
  ) => {
    const autoId = React.useId();
    const resolvedId = id ?? autoId;

    const resolvedErrorId = errorMessage
      ? (errorId ?? (resolvedId ? `${resolvedId}-error` : undefined))
      : undefined;

    const resolvedAriaDescribedBy =
      [ariaDescribedBy, resolvedErrorId].filter(Boolean).join(" ") || undefined;

    return (
      <div className={cn("grid gap-1", containerClassName)}>
        <label
          htmlFor={resolvedId}
          className={cn(
            "inline-flex items-center gap-2 text-sm text-black dark:text-white",
            props.disabled && "opacity-50",
            className
          )}
        >
          <input
            ref={ref}
            id={resolvedId}
            type="checkbox"
            aria-invalid={ariaInvalid ?? Boolean(errorMessage)}
            aria-describedby={resolvedAriaDescribedBy}
            className={
              "h-4 w-4 rounded border border-black/20 bg-transparent text-black accent-black focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-black/20 dark:border-white/20 dark:text-white dark:accent-white dark:focus-visible:ring-white/20"
            }
            {...props}
          />
          {label}
        </label>
        {errorMessage ? (
          <p
            id={resolvedErrorId}
            role="alert"
            className="text-sm text-red-600 dark:text-red-400"
          >
            {errorMessage}
          </p>
        ) : null}
      </div>
    );
  }
);

Checkbox.displayName = "Checkbox";
