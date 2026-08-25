import type { ReactNode } from 'react';
import { ChevronRight } from 'lucide-react';

export function PipelineStage({
  id,
  label,
  detail,
  icon,
  active,
  onClick,
}: {
  id: string;
  label: string;
  detail: string;
  icon: ReactNode;
  active: boolean;
  onClick: (id: string) => void;
}) {
  return (
    <button className={`stage ${active ? 'stage-active' : ''}`} onClick={() => onClick(id)}>
      <span className="stage-icon">{icon}</span>
      <span>
        <strong>{label}</strong>
        <small>{detail}</small>
      </span>
      <ChevronRight size={16} />
    </button>
  );
}
