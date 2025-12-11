import type { DialogId, DialogPayloads } from "../../types/dialog.types";
import { useDialogStore } from "./dialogStore";

export function useDialog() {
  const open = useDialogStore((s) => s.open);
  const close = useDialogStore((s) => s.close);

  return {
    openDialog: <K extends DialogId>(id: K, payload: DialogPayloads[K]) =>
      open(id, payload),
    closeDialog: close,
  };
}
