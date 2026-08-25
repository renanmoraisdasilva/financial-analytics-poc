export function ReportFilters({
  from,
  to,
  entity,
  setFrom,
  setTo,
  setEntity,
}: {
  from: string;
  to: string;
  entity: string;
  setFrom: (value: string) => void;
  setTo: (value: string) => void;
  setEntity: (value: string) => void;
}) {
  return (
    <div className="filters">
      <label>
        From
        <input type="date" value={from} onChange={(event) => setFrom(event.target.value)} />
      </label>
      <label>
        To
        <input type="date" value={to} onChange={(event) => setTo(event.target.value)} />
      </label>
      <label>
        Entity
        <select
          value={entity}
          onChange={(event) => setEntity(event.target.value)}
        >
          <option value="US">US / Northstar US</option>
          <option value="CA">CA / Northstar Canada</option>
        </select>
      </label>
    </div>
  );
}
