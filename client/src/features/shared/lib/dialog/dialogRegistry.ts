// src/shared/dialog/dialogRegistry.tsx

import CreateProjectDialog from "../../../projects/components/CreateProjectDialog";
import type { DialogId, DialogPayloads } from "../../types/dialog.types";

export type DialogComponent<K extends DialogId> = React.ComponentType<{
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
