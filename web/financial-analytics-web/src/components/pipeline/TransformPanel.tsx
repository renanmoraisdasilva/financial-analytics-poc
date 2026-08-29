import { ArrowRight } from 'lucide-react';
import { DataTable } from '../common/DataTable';
import type { DataTablePagination } from '../common/DataTable';
import type { PipelineError, Transformation } from '../../types/api';
import { money } from '../../utils/formatting';

export function TransformPanel({
  rows,
  errors,
  pagination,
}: {
  rows: Transformation[];
  errors: PipelineError[];
  pagination: DataTablePagination;
}) {
  const example = rows.find((row) => row.sourceTransactionId === 'A005');
  const path = example
    ? [
        {
          label: 'Account Code / Name',
          source: `${example.sourceAccountCode} / ${example.sourceAccountName}`,
          canonical: example.canonicalAccountCode && example.canonicalAccountName ? `${example.canonicalAccountCode} / ${example.canonicalAccountName}` : 'Unmapped',
          detail: example.canonicalAccountName ?? 'No canonical account',
          dimension: 'DimAccount',
          key: example.accountKey === null ? 'Not resolved' : `AccountKey: ${example.accountKey}`,
          subdetail: example.accountCategory ?? 'Unknown category',
        },
        {
          label: 'Entity Code',
          source: `${example.sourceEntityCode}`,
          canonical: example.sourceEntityCode,
          detail: example.entityName ?? 'Not resolved',
          dimension: 'DimEntity',
          key: example.entityKey === null ? 'Not resolved' : `EntityKey: ${example.entityKey}`,
        },
        {
          label: 'Date',
          source: example.transactionDate,
          canonical: example.dateKey === null ? 'Unmapped' : example.transactionDate,
          detail: '',
          dimension: 'DimDate',
          key: example.dateKey === null ? 'Not resolved' : `DateKey: ${example.dateKey}`,
          failed: example.dateKey === null,
        },
        {
          label: 'Currency',
          source: `${example.currencyCode}`,
          canonical: example.currencyCode,
          detail: example.currencyName ?? 'Not resolved',
          dimension: 'DimCurrency',
          key: example.currencyKey === null ? 'Not resolved' : `CurrencyKey: ${example.currencyKey}`,
        },
      ]
    : [];

  return (<>
    {errors.length > 0 && (
        <div className="validation-errors">
        {errors.map((error, index) => (
            <div key={`${error.code}-${error.sourceTransactionId ?? 'batch'}-${index}`}>
              <strong>
                {error.code}
                {error.sourceTransactionId ? ` / ${error.sourceTransactionId}` : ''}
              </strong>
              <p>{error.message}</p>
            </div>
          ))}
          </div>
        )}
        <div className="detail-body">
      <div className="transformation-path">
        <div className="path-heading">
          <p className="section-label">Transformation path</p>
          {example && <span>Example: {example.sourceTransactionId}</span>}
        </div>
        <div className="path-columns" aria-hidden="true">
          <span>Source ERP</span>
          <span>Canonical</span>
          <span>Dimension</span>
        </div>
        <div className="path-rows">
          {path.map((item) => (
            <div className={`path-row${item.failed ? ' path-row-failed' : ''}`} key={item.label}>
              <div className="path-source">
                <small>{item.label}</small>
                <strong>{item.source}</strong>
              </div>
              <ArrowRight className="path-arrow" aria-hidden="true" size={15} />
              <div className="path-source">
                <small>{item.label}</small>
                <strong>{item.canonical}</strong>
              </div>
              {/* <div className="path-canonical">
                <strong>{item.canonical}</strong>
                {item.detail && <span>{item.detail}</span>}
                {item.subdetail && <span>{item.subdetail}</span>}
              </div> */}
              <ArrowRight className="path-arrow" aria-hidden="true" size={15} />
              <div className="path-dimension">
                <strong>{item.dimension}</strong>
                <span>{item.key}</span>
              </div>
            </div>
          ))}
        </div>
      </div>
      <DataTable
        headers={[
          'Source ID',
          'Source account code',
          'Canonical account code',
          'Category',
          'Entity',
          'Date key',
          'Currency',
          'Amount',
          'Result',
        ]}
        rows={rows.map((row) => [
          row.sourceTransactionId,
          row.sourceAccountCode,
          row.canonicalAccountCode ?? 'Unmapped',
          row.accountCategory ?? 'Unknown',
          row.entityName ? `${row.sourceEntityCode} / ${row.entityName}` : 'Unmapped',
          row.dateKey?.toString() ?? 'Unmapped',
          row.currencyCode,
          money.format(row.amount),
          row.canonicalAccountCode && row.accountKey !== null && row.entityKey !== null && row.dateKey !== null && row.currencyKey !== null
            ? 'Mapped'
            : 'Unmapped',
        ])}
        rowClassName={(_, index) => {
          const row = rows[index];
          const isMapped = row.canonicalAccountCode && row.accountKey !== null && row.entityKey !== null && row.dateKey !== null && row.currencyKey !== null;
          return isMapped ? undefined : 'transform-row-failed';
        }}
        pagination={pagination}
      />

    </div>
  </>

  );
}
