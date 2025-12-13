import type { ComponentType } from "react";
import CreateProjectDialog from "../../../projects/components/CreateProjectDialog/CreateProjectDialog";
import type { DialogId, DialogPayloads } from "../../types/dialog.types";

export type DialogComponent<K extends DialogId> = ComponentType<{
  payload: DialogPayloads[K];
  onClose: () => void;
}>;

/**
 * Strongly-typed registry.
 * - If you forget a dialog key -> TS error.
 * - If a dialog component has wrong payload type -> TS error.
 */

export const dialogRegistry: {
  [K in DialogId]: DialogComponent<K>;
} = {
  "project.create": CreateProjectDialog,
};
