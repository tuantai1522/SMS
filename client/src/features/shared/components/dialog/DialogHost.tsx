// shared/dialog/DialogHost.tsx

import { dialogRegistry } from "../../lib/dialog/dialogRegistry";
import { useDialogStore } from "../../lib/dialog/dialogStore";

export function DialogHost() {
  const state = useDialogStore();
  const close = useDialogStore((s) => s.close);

  if (!state.isOpen) return null;

  const Dialog = dialogRegistry[state.id];

  return <Dialog payload={state.payload as any} onClose={close} />;
}
