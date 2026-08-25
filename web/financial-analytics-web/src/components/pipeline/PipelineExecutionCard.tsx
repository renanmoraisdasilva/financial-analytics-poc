import { CheckCircle2 } from 'lucide-react';
import type { Run } from '../../types/api';
import { formatDateTime } from '../../utils/formatting';

export function PipelineExecutionCard({ run }: { run: Run }) {
  return (
    <div className="run-card">
      <div className="card-heading">
        <div>
          <p className="section-label">Execution status</p>
          <strong>{run.status}</strong>
        </div>
        <span className={`status-pill ${run.status === 'Failed' ? 'failed' : ''}`}>
          <span />
          {run.status}
        </span>
      </div>
      <div className="progress-list">
        {[
          ['Extract', run.recordsExtracted],
          ['Transform', run.recordsTransformed],
          ['Validate', run.recordsValidated],
          ['Load', run.recordsLoaded],
        ].map(([label, count]) => (
          <div className="progress-row" key={label}>
            <span>
              <CheckCircle2 size={16} />
              {label}
            </span>
            <small>{count} records</small>
          </div>
        ))}
      </div>
      <div className="load-summary">
        <div className="section-label">Load result</div>
        <strong className="load-processed">{run.recordsLoaded} records processed</strong>
        <div className="load-stat-grid">
          <div>
            <span>Inserted</span>
            <strong>{run.recordsInserted}</strong>
            <small>New FactGL rows</small>
          </div>
          <div>
            <span>Already existing</span>
            <strong>{run.recordsAlreadyExisting}</strong>
            <small>Already in model</small>
          </div>
          <div>
            <span>Failed</span>
            <strong>{run.recordsFailed}</strong>
            <small>Not loaded</small>
          </div>
        </div>
        <div
          className={
            run.status === 'Completed' ? 'complete-label' : 'complete-label reconcile-fail'
          }
        >
          {run.status === 'Completed' ? '✓ Analytical model is up to date' : 'Review required'}
        </div>
      </div>
      <div className="run-meta">
        <span>
          Run ID <strong>#{run.pipelineRunId}</strong>
        </span>
        <span>Started {formatDateTime(run.startedAt)}</span>
        <span>Completed {formatDateTime(run.completedAt)}</span>
      </div>
    </div>
  );
}
