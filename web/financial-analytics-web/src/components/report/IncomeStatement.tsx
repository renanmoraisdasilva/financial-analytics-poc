import type { Report } from '../../types/api';
import { formatMoney } from '../../utils/formatting';

function StatementRow({
  label,
  value,
  negative,
  strong,
  muted,
  highlight,
  suffix = '',
  currencyCode,
}: {
  label: string;
  value: number;
  negative?: boolean;
  strong?: boolean;
  muted?: boolean;
  highlight?: boolean;
  suffix?: string;
  currencyCode?: string | null;
}) {
  return (
    <div
      className={`statement-row ${strong ? 'strong' : ''} ${muted ? 'muted' : ''} ${highlight ? 'highlight' : ''}`}
    >
      <span>{label}</span>
      <span className={negative ? 'negative' : ''}>
        {negative
          ? `(${formatMoney(Math.abs(value), currencyCode ?? undefined)})`
          : suffix
            ? `${value.toFixed(1)}${suffix}`
            : formatMoney(value, currencyCode ?? undefined)}
      </span>
    </div>
  );
}
export function IncomeStatement({ report }: { report: Report }) {
  return (
    <section className="income-statement">
      <div className="statement-head">
        <div>
          <p className="eyebrow">INCOME STATEMENT</p>
          <h2>
            {report.period.from} to {report.period.to}
          </h2>
        </div>
        <div className="report-tags">
          <span className="entity-tag">Entity: {report.entity ?? 'All entities'}</span>
          <span className="currency-tag">Currency: {report.currencyCode ?? 'Not specified'}</span>
        </div>
      </div>
      <StatementRow label="Revenue" value={report.revenue.total} strong currencyCode={report.currencyCode} />
      {report.revenue.lines.map((line) => (
        <div className="breakdown-row" key={line.account}>
          <span>{line.account}</span>
          <span>{formatMoney(line.amount, report.currencyCode ?? undefined)}</span>
        </div>
      ))}
      <StatementRow label="COGS" value={report.cogs.total} negative currencyCode={report.currencyCode} />
      {report.cogs.lines.map((line) => (
        <div className="breakdown-row" key={line.account}>
          <span>{line.account}</span>
          <span>{formatMoney(line.amount, report.currencyCode ?? undefined)}</span>
        </div>
      ))}
      <div className="statement-divider" />
      <StatementRow label="Gross Profit" value={report.grossProfit} strong currencyCode={report.currencyCode} />
      <StatementRow label="Gross Margin" value={report.grossMargin * 100} suffix="%" muted />
      <div className="statement-divider" />
      <StatementRow label="Operating Expenses" value={report.operatingExpenses.total} negative currencyCode={report.currencyCode} />
      {report.operatingExpenses.lines.map((line) => (
        <div className="breakdown-row" key={line.account}>
          <span>{line.account}</span>
          <span>{formatMoney(line.amount, report.currencyCode ?? undefined)}</span>
        </div>
      ))}
      <StatementRow label="Net Income" value={report.netIncome} strong highlight currencyCode={report.currencyCode} />
    </section>
  );
}
