import { ArrowRight } from 'lucide-react';
import { DataTable } from '../common/DataTable';
import type { DataTablePagination } from '../common/DataTable';
import type { Transformation } from '../../types/api';
import { formatDate, money } from '../../utils/formatting';

const formatPathDate = (value: string) => {
  const [year, month, day] = value.split('-');
  return `${new Intl.DateTimeFormat('en-US', { month: 'short' }).format(
    new Date(Number(year), Number(month) - 1, Number(day)),
  )} ${day} ${year}`;
};

export function TransformPanel({
  rows,
  pagination,
}: {
  rows: Transformation[];
  pagination: DataTablePagination;
}) {
  const example = rows.find((row) => row.canonicalAccountCode) ?? rows[0];
  const path = example
    ? [
        {
          label: 'Account',
          source: `Account ${example.sourceAccountCode}`,
          canonical: example.canonicalAccountCode ?? 'Unmapped',
          detail: example.canonicalAccountName ?? 'No canonical account',
          dimension: 'DimAccount',
          key: example.accountKey === null ? 'Not resolved' : `AccountKey: ${example.accountKey}`,
          subdetail: example.accountCategory ?? 'Unknown category',
        },
        {
          label: 'Entity',
          source: `Entity ${example.sourceEntityCode}`,
          canonical: example.sourceEntityCode,
          detail: example.entityName ?? 'Not resolved',
          dimension: 'DimEntity',
          key: example.entityKey === null ? 'Not resolved' : `EntityKey: ${example.entityKey}`,
        },
        {
          label: 'Date',
          source: formatPathDate(example.transactionDate),
          canonical: example.transactionDate,
          detail: '',
          dimension: 'DimDate',
          key: example.dateKey === null ? 'Not resolved' : `DateKey: ${example.dateKey}`,
        },
        {
          label: 'Currency',
          source: `Currency ${example.currencyCode}`,
          canonical: example.currencyCode,
          detail: example.currencyName ?? 'Not resolved',
          dimension: 'DimCurrency',
          key: example.currencyKey === null ? 'Not resolved' : `CurrencyKey: ${example.currencyKey}`,
        },
      ]
    : [];

  return (
    <div className="detail-body">
      <DataTable
        headers={['Source ID', 'Source account', 'Canonical account', 'Category', 'Amount']}
        rows={rows.map((row) => [
          row.sourceTransactionId,
          row.sourceAccountCode,
          row.canonicalAccountCode
            ? `${row.canonicalAccountCode} / ${row.canonicalAccountName}`
            : 'Unmapped',
          row.accountCategory ?? 'Unknown',
          money.format(row.amount),
        ])}
        pagination={pagination}
      />
      <div className="transformation-path">
        <div className="path-heading">
          <p className="section-label">Transformation path</p>
          {example && <span>Example: {example.sourceTransactionId}</span>}
        </div>
        <div className="path-columns" aria-hidden="true">
          <span>Source ERP</span>
          <span>Canonical account</span>
          <span>Dimension</span>
        </div>
        <div className="path-rows">
          {path.map((item) => (
            <div className="path-row" key={item.label}>
              <div className="path-source">
                <small>{item.label}</small>
                <strong>{item.source}</strong>
              </div>
              <ArrowRight className="path-arrow" aria-hidden="true" size={15} />
              <div className="path-canonical">
                <strong>{item.canonical}</strong>
                {item.detail && <span>{item.detail}</span>}
                {item.subdetail && <span>{item.subdetail}</span>}
              </div>
              <ArrowRight className="path-arrow" aria-hidden="true" size={15} />
              <div className="path-dimension">
                <strong>{item.dimension}</strong>
                <span>{item.key}</span>
              </div>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
}
