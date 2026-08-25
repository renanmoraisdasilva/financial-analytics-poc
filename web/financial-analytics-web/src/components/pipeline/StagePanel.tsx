import { Check } from 'lucide-react';
import type {
  AnalyticalRecord,
  PipelineScenario,
  Run,
  Source,
  Staging,
  Transformation,
  PipelineError,
  Validation,
} from '../../types/api';
import { SourcePanel } from './SourcePanel';
import { TransformPanel } from './TransformPanel';
import { ValidationPanel } from './ValidationPanel';
import { AnalyticalRecordsPanel } from './AnalyticalRecordsPanel';
import { LoadPanel } from './LoadPanel';
import type { DataTablePagination } from '../common/DataTable';

export function StagePanel({
  stage,
  run,
  source,
  staging,
  transformations,
  validation,
  errors,
  analyticalRecords,
  analyticalSummary,
  scenario,
  onScenarioChange,
  sourcePagination,
  stagingPagination,
  transformationPagination,
  analyticalPagination,
  onSourcePageChange,
  onStagingPageChange,
  onTransformationPageChange,
  onAnalyticalPageChange,
}: {
  stage: string;
  run: Run | null;
  source: Source[];
  staging: Staging[];
  transformations: Transformation[];
  validation: Validation | null;
  errors: PipelineError[];
  analyticalRecords: AnalyticalRecord[];
  analyticalSummary: {
    accountCount: number;
    entityCount: number;
    dateCount: number;
    currencyCount: number;
  };
  scenario: PipelineScenario;
  onScenarioChange: (scenario: PipelineScenario) => void;
  sourcePagination: DataTablePagination;
  stagingPagination: DataTablePagination;
  transformationPagination: DataTablePagination;
  analyticalPagination: DataTablePagination;
  onSourcePageChange: (page: number) => void;
  onStagingPageChange: (page: number) => void;
  onTransformationPageChange: (page: number) => void;
  onAnalyticalPageChange: (page: number) => void;
}) {
  const titles: Record<string, [string, string]> = {
    erp: ['Source data', 'Fake ERP operational records'],
    extract: ['Extract', 'Raw source data captured for processing'],
    staging: ['Staging', 'Source records captured for this pipeline run'],
    transform: ['Transform', 'Source vocabulary mapped to canonical accounts'],
    validate: ['Validate', 'Integrity and reconciliation checks'],
    load: ['Load', 'Records written to the analytical model'],
    analytical: ['Analytical records', 'Current records in the financial model'],
  };
  const [title, subtitle] = titles[stage];
  const transformFailed = Boolean(
    run?.validation === null && errors.some((error) => error.phase === 'Transform'),
  );
  const validationFailed = run?.validation?.isValid === false;
  const status =
    (stage === 'validate' && transformFailed) ||
    (stage === 'load' && (transformFailed || validationFailed))
      ? 'Not executed'
      : (stage === 'transform' && transformFailed) || (stage === 'validate' && validationFailed)
        ? 'Review required'
        : 'Complete';
  return (
    <>
      <div className="detail-header">
        <div>
          <p className="eyebrow">STAGE {stage === 'erp' ? 'SOURCE' : stage.toUpperCase()}</p>
          <h2>{title}</h2>
          <p>{subtitle}</p>
        </div>
        {run && (
          <span className="complete-label">
            <Check size={15} /> {status}
          </span>
        )}
      </div>
      {!run && stage !== 'erp' && stage !== 'analytical' ? (
        <div className="detail-body">
          <div className="empty-state">
            <span>
              {stage === 'extract' ? 'Run the pipeline to capture source records.' : 'Not run yet'}
            </span>
          </div>
        </div>
      ) : stage === 'validate' ? (
        <ValidationPanel validation={validation} errors={errors} />
      ) : stage === 'transform' ? (
        <TransformPanel rows={transformations} pagination={transformationPagination} />
      ) : stage === 'analytical' ? (
        <AnalyticalRecordsPanel
          rows={analyticalRecords}
          pagination={analyticalPagination}
          summary={analyticalSummary}
        />
      ) : stage === 'load' ? (
        <LoadPanel run={run!} />
      ) : (
        <SourcePanel
          rows={stage === 'erp' ? source : staging}
          compact={stage === 'extract'}
          emptyMessage={stage === 'staging' && !staging.length ? 'Not run yet' : undefined}
          scenario={stage === 'erp' ? scenario : undefined}
          onScenarioChange={stage === 'erp' ? onScenarioChange : undefined}
          pagination={stage === 'erp' ? sourcePagination : stagingPagination}
          onPageChange={stage === 'erp' ? onSourcePageChange : onStagingPageChange}
        />
      )}
    </>
  );
}
