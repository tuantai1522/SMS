// src/shared/dialog/dialogStore.ts

import { create } from "zustand";
import type {
  DialogId,
  DialogPayloads,
  DialogState,
} from "../../types/dialog.types";

type DialogActions = {
  open: <K extends DialogId>(id: K, payload: DialogPayloads[K]) => void;
  close: () => void;
};

export const useDialogStore = create<DialogState & DialogActions>((set) => ({
  isOpen: false,

  open: (id, payload) =>
    set({
      isOpen: true,
      id,
      payload,
    } as DialogState),

  close: () => set({ isOpen: false }),
}));
