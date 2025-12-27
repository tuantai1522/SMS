import { forwardRef, useState, type ComponentProps } from "react";
import { Eye, EyeOff } from "lucide-react";
import { cn } from "../../../../lib/utils/cn";
import { Input } from "./Input";

type PasswordInputProps = Omit<ComponentProps<"input">, "type"> & {
  defaultVisible?: boolean;
};

export const PasswordInput = forwardRef<HTMLInputElement, PasswordInputProps>(
  ({ className, defaultVisible = false, disabled, ...props }, ref) => {
    const [visible, setVisible] = useState(defaultVisible);

    return (
      <div className="relative">
        <Input
          ref={ref}
          disabled={disabled}
          type={visible ? "text" : "password"}
          className={cn("pr-12", className)}
          {...props}
        />

        <button
          type="button"
          disabled={disabled}
          aria-label={visible ? "Hide password" : "Show password"}
          aria-pressed={visible}
          onClick={() => setVisible((v) => !v)}
          className={cn(
            "absolute inset-y-0 right-0 flex w-12 items-center justify-center rounded-r-xl cursor-pointer text-black/60 transition focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-black/15  dark:text-white/60  dark:focus-visible:ring-white/15"
          )}
        >
          {visible ? (
            <EyeOff className="h-6 w-6" aria-hidden="true" />
          ) : (
            <Eye className="h-6 w-6" aria-hidden="true" />
          )}
        </button>
      </div>
    );
  }
);

PasswordInput.displayName = "PasswordInput";
