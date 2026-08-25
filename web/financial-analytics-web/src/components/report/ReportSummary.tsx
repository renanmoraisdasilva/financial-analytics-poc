import type { Report } from '../../types/api';
import { formatMoney } from '../../utils/formatting';

export function ReportSummary({ report }: { report: Report }) {
  return (
    <div className="report-summary">
      <div>
        <span>Revenue</span>
        <strong>{formatMoney(report.revenue.total, report.currencyCode ?? undefined)}</strong>
      </div>
      <div>
        <span>Gross profit</span>
        <strong>{formatMoney(report.grossProfit, report.currencyCode ?? undefined)}</strong>
      </div>
      <div>
        <span>Gross margin</span>
        <strong>{(report.grossMargin * 100).toFixed(1)}%</strong>
      </div>
      <div className="summary-net">
        <span>Net income</span>
        <strong>{formatMoney(report.netIncome, report.currencyCode ?? undefined)}</strong>
      </div>
    </div>
  );
}
