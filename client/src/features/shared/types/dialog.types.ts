// src/shared/dialog/types.ts

export type DialogPayloads = {
  "project.create": { workspaceId: string };
};

export type DialogId = keyof DialogPayloads;

/**
 * Union state that preserves correlation between id and payload.
 * This is the key to strong typing in the host.
 */
export type OpenState = {
  [K in DialogId]: {
    isOpen: true;
    id: K;
    payload: DialogPayloads[K];
  };
}[DialogId];

export type DialogState = { isOpen: false } | OpenState;
