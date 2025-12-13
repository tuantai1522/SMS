import EmojiPickerComponent from "../../../shared/components/emojis";
import type { DialogPayloads } from "../../../shared/types/dialog.types";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "../../../shared/components/ui/Form";
import { Button } from "../../../shared/components/ui/Button";
import { Textarea } from "../../../shared/components/ui/Textarea";
import { Input } from "../../../shared/components/ui/Input";
import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from "@radix-ui/react-popover";
import { Loader } from "lucide-react";
import Dialog from "../../../shared/components/dialog/Dialog";
import { useCreateProjectDialog } from "./CreateProjectDialog.hooks";

type Props = {
  payload: DialogPayloads["project.create"];
  onClose: () => void;
};

export default function CreateProjectDialog({ payload, onClose }: Props) {
  const {
    form,
    handleSubmit,
    isLoading,

    emoji,
    setEmoji,

    openEmojiDialog,
    setOpenEmojiDialog,
  } = useCreateProjectDialog({ workspaceId: payload.workspaceId });

  return (
    <>
      <Dialog
        title="Create Project"
        subTitle="Organize and manage tasks, resources, and team collaboration"
      >
        <Form {...form}>
          <form onSubmit={handleSubmit}>
            <div className="mb-4">
              <label className="block text-sm font-medium text-gray-700">
                Select Emoji
              </label>
              <Popover open={openEmojiDialog} onOpenChange={setOpenEmojiDialog}>
                <PopoverTrigger asChild>
                  <Button
                    variant="outline"
                    className="font-normal size-[60px] !p-2 !shadow-none mt-2 items-center rounded-full "
                  >
                    <span className="text-4xl">{emoji}</span>
                  </Button>
                </PopoverTrigger>
                <PopoverContent
                  side="right"
                  align="start"
                  sideOffset={8}
                  className=" !p-0"
                >
                  <EmojiPickerComponent
                    onChange={(val) => {
                      setEmoji(val);
                      setOpenEmojiDialog(false);
                    }}
                  />
                </PopoverContent>
              </Popover>
            </div>
            <div className="mb-4">
              <FormField
                control={form.control}
                name="name"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel className="dark:text-[#f1f7feb5] text-sm">
                      Project name
                    </FormLabel>
                    <FormControl>
                      <Input
                        placeholder="Website Redesign"
                        className="!h-[48px]"
                        {...field}
                      />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />
            </div>
            <div className="mb-4">
              <FormField
                control={form.control}
                name="code"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel className="dark:text-[#f1f7feb5] text-sm">
                      Project code
                    </FormLabel>
                    <FormControl>
                      <Input
                        placeholder="Project code"
                        className="!h-[48px]"
                        {...field}
                      />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />
            </div>
            <div className="mb-4">
              <FormField
                control={form.control}
                name="description"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel className="dark:text-[#f1f7feb5] text-sm">
                      Project description
                      <span className="text-xs font-extralight ml-2">
                        Optional
                      </span>
                    </FormLabel>
                    <FormControl>
                      <Textarea
                        rows={4}
                        placeholder="Projects description"
                        {...field}
                        className="resize-none"
                      />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />
            </div>

            <div className="flex justify-end gap-2">
              <Button
                disabled={isLoading}
                type="button"
                onClick={onClose}
                variant="outline"
                className="h-[40px] px-4 font-semibold border-neutral-300 text-neutral-700 hover:bg-neutral-100"
              >
                {isLoading ? <Loader className="animate-spin" /> : "Cancel"}
              </Button>

              <Button
                disabled={isLoading}
                type="submit"
                className="h-[40px] px-4 font-semibold bg-black text-white hover:bg-black/90"
              >
                {isLoading ? <Loader className="animate-spin" /> : "Create"}
              </Button>
            </div>
          </form>
        </Form>
      </Dialog>
    </>
  );
}
