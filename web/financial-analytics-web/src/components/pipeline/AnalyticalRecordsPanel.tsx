import { DataTable } from '../common/DataTable';
import type { DataTablePagination } from '../common/DataTable';
import { Metric } from '../common/Metric';
import type { AnalyticalRecord } from '../../types/api';
import { formatDate, money } from '../../utils/formatting';

function AnalyticalModel() {
  return (
    <section className="analytical-model" aria-labelledby="analytical-model-title">
      <div className="analytical-model-heading">
        <div>
          <p className="eyebrow">MODEL CONTEXT</p>
          <h3 id="analytical-model-title">Analytical Model</h3>
        </div>
      </div>
      <div
        className="analytical-model-diagram"
        role="img"
        aria-label="FactGL is the central transaction fact table, related to Account, Entity, Date, and Currency dimensions."
      >
        <div className="model-node model-account">
          <strong>DimAccount</strong>
          <span>AccountKey / Category</span>
          <small>Business context</small>
          <span className="model-link model-link-account" aria-hidden="true" />
        </div>
        <div className="model-node model-date">
          <strong>DimDate</strong>
          <span>DateKey</span>
          <small>Time context</small>
        </div>
        <div className="model-node model-fact">
          <strong>FactGL</strong>
          <span>1 row = 1 transaction</span>
          <small>Measures + foreign keys</small>
          <span className="model-link model-link-date" aria-hidden="true" />
          <span className="model-link model-link-entity" aria-hidden="true" />
        </div>
        <div className="model-node model-entity">
          <strong>DimEntity</strong>
          <span>EntityKey</span>
          <small>Business context</small>
        </div>
        <div className="model-node model-currency">
          <strong>DimCurrency</strong>
          <span>CurrencyKey</span>
          <small>Currency context</small>
          <span className="model-link model-link-currency" aria-hidden="true" />
        </div>
      </div>
    </section>
  );
}

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
      <AnalyticalModel />
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
