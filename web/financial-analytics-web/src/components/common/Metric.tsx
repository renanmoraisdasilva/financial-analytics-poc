export function Metric({
  label,
  value,
  accent,
}: {
  label: string;
  value: string;
  accent?: boolean;
}) {
  return (
    <div className={`metric ${accent ? 'metric-accent' : ''}`}>
      <span>{label}</span>
      <strong>{value}</strong>
    </div>
  );
}
