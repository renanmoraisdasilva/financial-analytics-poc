import { DataTable } from '../common/DataTable';
import type { DataTablePagination } from '../common/DataTable';
import { Metric } from '../common/Metric';
import {
  pipelineScenarioOptions,
  type PipelineError,
  type PipelineScenario,
  type Run,
  type Source,
} from '../../types/api';
import { formatDate, money } from '../../utils/formatting';

export function SourcePanel({
  rows,
  compact,
  run,
  errors,
  emptyMessage,
  scenario,
  onScenarioChange,
  pagination,
  onPageChange,
}: {
  rows: Source[];
  compact: boolean;
  run: Run | null;
  errors: PipelineError[];
  emptyMessage?: string;
  scenario?: PipelineScenario;
  onScenarioChange?: (scenario: PipelineScenario) => void;
  pagination: DataTablePagination;
  onPageChange: (page: number) => void;
}) {
  if (emptyMessage)
    return (
      <div className="detail-body">
        <div className="empty-state">
          <span>{emptyMessage}</span>
        </div>
      </div>
    );
  return (
    <div className="detail-body">
      {scenario && onScenarioChange && (
        <div className="scenario-selector" aria-label="Source data scenario">
          <div className="scenario-options">
            {pipelineScenarioOptions.map((option) => (
              <button
                className={option.value === scenario ? 'scenario-option selected' : 'scenario-option'}
                key={option.value}
                onClick={() => onScenarioChange(option.value)}
                type="button"
              >
                {option.label}
              </button>
            ))}
          </div>
          <p>
            {pipelineScenarioOptions.find((option) => option.value === scenario)?.description}
          </p>
        </div>
      )}
      {compact ? (
        <div className="metric-grid">
          <Metric label="Source" value="Fake ERP" />
          <Metric label="Records read" value={`${run?.recordsExtracted ?? 0}`} />
          <Metric
            label="Capture status"
            value={errors.some((error) => error.phase === 'Extract') ? 'Failed' : '100% success'}
            accent={!errors.some((error) => error.phase === 'Extract')}
          />
          {errors.some((error) => error.phase === 'Extract') && (
            <div className="validation-errors">
              {errors
                .filter((error) => error.phase === 'Extract')
                .map((error, index) => (
                  <div key={`${error.code}-${index}`}>
                    <strong>{error.code}</strong>
                    <p>{error.message}</p>
                  </div>
                ))}
            </div>
          )}
        </div>
      ) : (
        <DataTable
          headers={['Source ID', 'Date', 'Account code / name', 'Description', 'Amount', 'Currency', 'Entity']}
          rows={rows.map((row) => [
            row.sourceTransactionId,
            formatDate(row.transactionDate),
            `${row.sourceAccountCode} / ${row.sourceAccountName}`,
            row.description ?? 'No description',
            money.format(row.amount),
            row.currencyCode,
            row.sourceEntityCode,
          ])}
          pagination={{ ...pagination, onPageChange }}
        />
      )}
    </div>
  );
}
