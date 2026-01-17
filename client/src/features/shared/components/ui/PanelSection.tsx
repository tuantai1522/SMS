import { useState } from "react";
import { ChevronRight, ChevronDown } from "lucide-react";

interface PanelSectionProps {
  title: string;
  items: PanelItem[];
  defaultOpen?: boolean;
}

export function PanelSection({
  title,
  items,
  defaultOpen = true,
}: PanelSectionProps) {
  const [isOpen, setIsOpen] = useState(defaultOpen);

  return (
    <div className="collapse">
      <input
        type="checkbox"
        checked={isOpen}
        onChange={(e) => setIsOpen(e.target.checked)}
      />
      <div className="collapse-title text-sm font-medium px-2 py-2 min-h-0 flex items-center justify-between ">
        <span className="text-xs font-semibold text-base-content/60">
          {title}
        </span>
        {isOpen ? (
          <ChevronDown className="h-4 w-4" />
        ) : (
          <ChevronRight className="h-4 w-4" />
        )}
      </div>
      <div className="collapse-content px-0">
        <ul className="menu w-full">
          {items.map((item) => (
            <PanelSectionItem key={item.id} emoji={item.emoji} name={item.name} />
          ))}
        </ul>
      </div>
    </div>
  );
}


interface PanelSectionItemProps {
  emoji: string | null;
  name: string;
}

function PanelSectionItem({ emoji, name }: PanelSectionItemProps) {
  const displayEmoji = emoji || "📁";

  return (
    <li>
    <div className="flex items-center gap-2 px-2 py-1.5 text-sm">
      <span className="text-lg">{displayEmoji}</span>
      <span className="text-xs">{name}</span>
    </div>
    </li>
  );
}


export interface PanelItem {
  id: string;
  name: string;
  emoji: string | null;
}