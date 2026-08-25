import { Metric } from '../common/Metric';
import type { Run } from '../../types/api';

export function LoadPanel({ run }: { run: Run }) {
  return (
    <div className="detail-body">
      <div className="metric-grid four">
        <Metric label="Processed" value={`${run.recordsLoaded}`} />
        <Metric label="Inserted" value={`${run.recordsInserted}`} accent />
        <Metric label="Already existing" value={`${run.recordsAlreadyExisting}`} />
        <Metric label="Failed" value={`${run.recordsFailed}`} />
      </div>
    </div>
  );
}
