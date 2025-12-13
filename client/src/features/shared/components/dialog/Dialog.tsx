import { type ReactNode } from "react";
import { useDialog } from "../../lib/dialog/useDialog";

type Props = {
  title: string;
  subTitle: string;
  children: ReactNode;
};

export default function Dialog({ title, subTitle, children }: Props) {
  const { closeDialog } = useDialog();

  return (
    <div className="fixed inset-0 z-50 flex items-center justify-center bg-black/40">
      <div className="w-full max-w-md max-h-[80vh] overflow-y-auto rounded-2xl bg-white p-5 shadow">
        <div className="relative mb-5 border-b pb-2">
          <h1
            className="text-xl tracking-[-0.16px] dark:text-[#fcfdffef] font-semibold mb-1
           text-center sm:text-left"
          >
            {title}
          </h1>
          <p className="text-muted-foreground text-sm leading-tight">
            {subTitle}
          </p>

          <button
            type="button"
            onClick={closeDialog}
            className="absolute right-0 top-0 inline-flex h-8 w-8 items-center justify-center rounded-full
               text-neutral-400 hover:bg-neutral-100 hover:text-neutral-700"
            aria-label="Close"
          >
            ✕
          </button>
        </div>

        {children}
      </div>
    </div>
  );
}
