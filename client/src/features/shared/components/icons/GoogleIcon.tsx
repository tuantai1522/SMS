import * as React from "react";

export function GoogleIcon(props: React.SVGProps<SVGSVGElement>) {
  return (
    <svg
      viewBox="0 0 24 24"
      width="18"
      height="18"
      aria-hidden
      focusable={false}
      {...props}
    >
      <path
        d="M12 2a10 10 0 1 0 0 20 9.7 9.7 0 0 0 6.9-2.7 8.7 8.7 0 0 0 2.6-6.2c0-.6-.1-1.2-.2-1.8H12v3.4h5.4a4.7 4.7 0 0 1-2 3.1A6 6 0 1 1 18 8.9l2.4-2.4A9.9 9.9 0 0 0 12 2Z"
        fill="currentColor"
      />
    </svg>
  );
}
