import { DataTable } from '../common/DataTable';
import type { DataTablePagination } from '../common/DataTable';
import { Metric } from '../common/Metric';
import type { AnalyticalRecord } from '../../types/api';
import { formatDate, money } from '../../utils/formatting';

export function AnalyticalRecordsPanel({
  rows,
  pagination,
  summary,
}: {
  rows: AnalyticalRecord[];
  pagination: DataTablePagination;
  summary: {
    accountCount: number;
    entityCount: number;
    dateCount: number;
    currencyCount: number;
  };
}) {
  return (
    <div className="detail-body">
      <div className="metric-grid five">
        <Metric label="FactGL" value={`${pagination.totalCount} rows`} accent />
        <Metric label="Accounts" value={`${summary.accountCount}`} />
        <Metric label="Entities" value={`${summary.entityCount}`} />
        <Metric label="Dates" value={`${summary.dateCount}`} />
        <Metric label="Currencies" value={`${summary.currencyCount}`} />
      </div>
      <DataTable
        headers={['Transaction', 'Date', 'Account', 'Category', 'Entity', 'Currency', 'Amount']}
        rows={rows.map((row) => [
          row.sourceTransactionId,
          formatDate(row.transactionDate),
          `${row.accountCode} / ${row.accountName}`,
          row.accountCategory,
          row.entityCode,
          row.currencyCode,
          money.format(row.amount),
        ])}
        pagination={pagination}
      />
    </div>
  );
}
