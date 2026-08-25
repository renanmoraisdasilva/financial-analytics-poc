import { AlertTriangle, Check, CheckCircle2 } from 'lucide-react';
import type { PipelineError, Validation } from '../../types/api';
import { formatMoney } from '../../utils/formatting';

export function ValidationPanel({
  validation,
  errors = [],
}: {
  validation: Validation | null;
  errors?: PipelineError[];
}) {
  const diagnostics = validation?.errors ?? errors;
  if (!validation)
    return (
      <div className="detail-body">
        <div>
          <div className="empty-state">
            <span>{errors.length > 0 ? 'Validation skipped' : 'Not run yet'}</span>
          </div>
          {errors.length > 0 && (
            <div className="validation-errors">
              {errors.map((error, index) => (
                <div key={`${error.phase}-${error.code}-${error.sourceTransactionId ?? 'batch'}-${index}`}>
                  <strong>
                    {error.phase} / {error.code}
                    {error.sourceTransactionId ? ` / ${error.sourceTransactionId}` : ''}
                  </strong>
                  <p>{error.message}</p>
                </div>
              ))}
            </div>
          )}
        </div>
      </div>
    );
  const checks = [
    ['Records received', `${validation.recordsReceived}`],
    ['Transformation errors', `${validation.transformationErrors}`],
    ['Accounts mapped', `${validation.accountsMapped}`],
    ['Valid dates', `${validation.validDates}`],
    ['Duplicates', `${validation.duplicates}`],
    ['Invalid amounts', `${validation.invalidAmounts}`],
  ];
  return (
    <div className="detail-body validation-grid">
      <div>
        <p className="section-label">Validation summary</p>
        {checks.map(([label, value]) => (
          <div className="check-row" key={label}>
            <CheckCircle2 size={17} />
            <span>{label}</span>
            <strong>{value}</strong>
          </div>
        ))}
        {diagnostics.length > 0 && (
          <div className="validation-errors">
            {diagnostics.map((error, index) => (
              <div key={`${error.phase}-${error.code}-${error.sourceTransactionId ?? 'batch'}-${index}`}>
                <strong>
                  {error.phase} / {error.code}
                  {error.sourceTransactionId ? ` / ${error.sourceTransactionId}` : ''}
                </strong>
                <p>{error.message}</p>
              </div>
            ))}
          </div>
        )}
      </div>
      <div className="reconcile">
        <p className="section-label">Reconciliation</p>
        <div className="reconcile-header">
          <span>Currency</span>
          <span>Source total</span>
          <span>Transformed total</span>
          <span>Difference</span>
        </div>
        {validation.reconciliationByCurrency.map((item) => (
          <div
            className={`reconcile-row ${item.difference === 0 ? 'reconcile-pass' : 'reconcile-fail'}`}
            key={item.currency}
          >
            <strong>{item.currency}</strong>
            <strong>{formatMoney(item.sourceTotal, item.currency)}</strong>
            <strong>{formatMoney(item.transformedTotal, item.currency)}</strong>
            <strong>{formatMoney(item.difference, item.currency)}</strong>
          </div>
        ))}
        <p className={validation.reconciliationPassed ? 'reconcile-pass' : 'reconcile-fail'}>
          {validation.reconciliationPassed ? <Check size={18} /> : <AlertTriangle size={18} />}{' '}
          {validation.reconciliationPassed ? 'Reconciliation passed' : 'Reconciliation failed'}
        </p>
      </div>
    </div>
  );
}
