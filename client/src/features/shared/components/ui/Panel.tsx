import type { ReactNode } from "react";

interface PanelProps {
  title: string;
  children: ReactNode;
}

export function Panel({ title, children }: PanelProps) {
  return (
    <div className="flex min-h-full w-64 flex-col bg-base-200">
      <div className="px-4 py-3">
        <h2 className="text-lg font-semibold">{title}</h2>
      </div>
      <div className="flex-1 overflow-y-auto px-2">
        {children}
      </div>
    </div>
  );
}
