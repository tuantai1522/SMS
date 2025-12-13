import { dialogRegistry } from "../../lib/dialog/dialogRegistry";
import { useDialogStore } from "../../lib/dialog/dialogStore";

export function DialogHost() {
  const state = useDialogStore();

  if (!state.isOpen) return null;

  const Dialog = dialogRegistry[state.id];

  return <Dialog payload={state.payload} onClose={state.close} />;
}
