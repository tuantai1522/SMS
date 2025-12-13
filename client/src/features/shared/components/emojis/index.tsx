import EmojiPicker, {
  type EmojiClickData,
  EmojiStyle,
  Theme,
} from "emoji-picker-react";
import React from "react";

type EmojiPickerComponentProps = {
  onChange: (emoji: string) => void;
  className?: string;
};

export const EmojiPickerComponent: React.FC<EmojiPickerComponentProps> = ({
  onChange,
  className,
}) => {
  const handleEmojiClick = (emojiData: EmojiClickData) => {
    onChange(emojiData.emoji);
  };

  return (
    <div className={className}>
      <EmojiPicker
        previewConfig={{ showPreview: false }}
        onEmojiClick={handleEmojiClick}
        emojiStyle={EmojiStyle.NATIVE}
        theme={Theme.LIGHT}
        lazyLoadEmojis
        width={300}
        height={350}
      />
    </div>
  );
};

export default EmojiPickerComponent;
