import { useState } from "react";
import { useCreateProject } from "../../hooks/mutations/useCreateProject";
import {
  createProjectSchema,
  type CreateProjectSchema,
} from "./CreateProjectDialog.schema";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { ProjectEnv } from "../../config/env";

interface Props {
  workspaceId: string;
}
export function useCreateProjectDialog({ workspaceId }: Props) {
  const [emoji, setEmoji] = useState<string>(ProjectEnv.DEFAULT_EMOJI);
  const [openEmojiDialog, setOpenEmojiDialog] = useState(false);

  const createProjectMutation = useCreateProject();

  const form = useForm<CreateProjectSchema>({
    resolver: zodResolver(createProjectSchema),
    defaultValues: {
      name: "",
      code: "",
      emoji: emoji,
      workspaceId,
      description: "",
    },
  });

  const handleSubmit = form.handleSubmit(async (data) => {
    const payload = {
      ...data,
      emoji,
    };

    createProjectMutation.mutateAsync(payload, {
      onSuccess: async () => {
        form.reset();

        setEmoji(ProjectEnv.DEFAULT_EMOJI);
      },
    });
  });

  return {
    form,
    handleSubmit,

    emoji,
    setEmoji,

    openEmojiDialog,
    setOpenEmojiDialog,

    isLoading: createProjectMutation.isPending,
  };
}
