import { cn } from "../../../../lib/utils/cn";

interface MaterialIconProps extends React.HTMLAttributes<HTMLSpanElement> {
  name: string;
  size?: number;
  weight?: "200" | "300" | "400" | "500" | "600";
}

export const MaterialIcon = ({
  name,
  size = 20,
  weight = "400",
  className,
  ...props
}: MaterialIconProps) => {
  return (
    <span
      {...props}
      className={cn("material-symbols-outlined select-none", className)}
      style={{
        fontSize: size,
        fontVariationSettings: `"FILL" 0, "wght" ${weight}, "GRAD" 0, "opsz" ${size}`,
      }}
    >
      {name}
    </span>
  );
};
