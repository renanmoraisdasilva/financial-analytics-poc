import { useEffect, useState } from 'react';
import { ArrowDown, Database, FileCheck2, Layers3, Play, RefreshCw, RotateCcw } from 'lucide-react';
import { pipelineApi } from '../api/pipelineApi';
import type {
  AnalyticalRecord,
  AnalyticalPage,
  Page,
  PipelineScenario,
  Run,
  Source,
  Staging,
  Transformation,
  Validation,
} from '../types/api';
import { PipelineConnector } from '../components/pipeline/PipelineConnector';
import { PipelineExecutionCard } from '../components/pipeline/PipelineExecutionCard';
import { PipelineStage } from '../components/pipeline/PipelineStage';
import { StagePanel } from '../components/pipeline/StagePanel';

const tablePageSize = 25;
const emptyPage = <T,>(): Page<T> => ({
  items: [],
  page: 1,
  pageSize: tablePageSize,
  totalCount: 0,
  totalPages: 0,
});
const emptyAnalyticalPage = (): AnalyticalPage => ({
  ...emptyPage<AnalyticalRecord>(),
  accountCount: 0,
  entityCount: 0,
  dateCount: 0,
  currencyCount: 0,
});

export function PipelinePage() {
  const [run, setRun] = useState<Run | null>(null);
  const [stage, setStage] = useState('erp');
  const [source, setSource] = useState<Page<Source>>(emptyPage);
  const [staging, setStaging] = useState<Page<Staging>>(emptyPage);
  const [transformations, setTransformations] = useState<Page<Transformation>>(emptyPage);
  const [analyticalRecords, setAnalyticalRecords] = useState<AnalyticalPage>(emptyAnalyticalPage);
  const [validation, setValidation] = useState<Validation | null>(null);
  const [running, setRunning] = useState(false);
  const [resetting, setResetting] = useState(false);
  const [resetConfirmOpen, setResetConfirmOpen] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [scenario, setScenario] = useState<PipelineScenario>('happy');

  const loadSourcePage = async (page: number) => {
    setSource(await pipelineApi.sourceTransactions(page, tablePageSize));
  };
  const loadAnalyticalPage = async (page: number) => {
    setAnalyticalRecords(await pipelineApi.analyticalRecords(page, tablePageSize));
  };
  const loadStagingPage = async (page: number) => {
    if (!run) return;
    setStaging(await pipelineApi.pipelineRunStaging(run.pipelineRunId, page, tablePageSize));
  };
  const loadTransformationPage = async (page: number) => {
    if (!run) return;
    setTransformations(
      await pipelineApi.pipelineRunTransformations(run.pipelineRunId, page, tablePageSize),
    );
  };
  const loadData = async (id?: number, currentRun?: Run) => {
    const [sourceData, analyticalRecordData] = await Promise.all([
      pipelineApi.sourceTransactions(1, tablePageSize),
      pipelineApi.analyticalRecords(1, tablePageSize),
    ]);
    setSource(sourceData);
    setAnalyticalRecords(analyticalRecordData);
    if (id) {
      const current = currentRun ?? (await pipelineApi.pipelineRun(id));
      const [stagingData, transformationData, validationData] = await Promise.all([
        pipelineApi.pipelineRunStaging(id, 1, tablePageSize),
        pipelineApi.pipelineRunTransformations(id, 1, tablePageSize),
        currentRun?.validation === null ? Promise.resolve(null) : pipelineApi.pipelineRunValidation(id),
      ]);
      setRun(current);
      setStaging(stagingData);
      setTransformations(transformationData);
      setValidation(validationData);
    }
  };
  useEffect(() => {
    let cancelled = false;
    Promise.all([
      pipelineApi.sourceTransactions(1, tablePageSize),
      pipelineApi.analyticalRecords(1, tablePageSize),
    ])
      .then(([sourceData, analyticalRecordData]) => {
        if (cancelled) return;
        setSource(sourceData);
        setAnalyticalRecords(analyticalRecordData);
      })
      .catch((error) => {
        if (!cancelled) {
          setError(error instanceof Error ? error.message : 'Data could not be loaded.');
        }
      });
    return () => {
      cancelled = true;
    };
  }, []);

  const selectScenario = (selectedScenario: PipelineScenario) => {
    setScenario(selectedScenario);
    setRun(null);
    setStaging(emptyPage());
    setTransformations(emptyPage());
    setValidation(null);
    setStage('erp');
    setError(null);
  };

  const execute = async () => {
    setRunning(true);
    setError(null);
    try {
      const result = await pipelineApi.runPipeline(scenario);
      await loadData(result.pipelineRunId, result);
    } finally {
      setRunning(false);
    }
  };
  const reset = async () => {
    setResetting(true);
    setError(null);
    try {
      await pipelineApi.resetPipeline();
      setRun(null);
      setStaging(emptyPage());
      setTransformations(emptyPage());
      setValidation(null);
      await loadAnalyticalPage(1);
      setResetConfirmOpen(false);
      setStage('erp');
    } catch (error) {
      setError(error instanceof Error ? error.message : 'The pipeline could not be reset.');
    } finally {
      setResetting(false);
    }
  };
  return (
    <main className="page">
      <div className="page-heading">
        <div>
          <p className="eyebrow">OPERATIONS / ETL CONTROL</p>
          <h1>Data Pipeline</h1>
          <p className="lede">Trace every source record from Fake ERP into the analytical model.</p>
        </div>
        <div className="pipeline-actions">
          <button className="primary-button" onClick={execute} disabled={running || resetting}>
            <Play size={16} fill="currentColor" />
            {running ? 'Running...' : 'Run pipeline'}
          </button>
          <button
            className="danger-button"
            onClick={() => setResetConfirmOpen(true)}
            disabled={running || resetting}
          >
            <RotateCcw size={16} />
            {resetting ? 'Resetting...' : 'Reset pipeline'}
          </button>
        </div>
      </div>
      {error && <div className="error-banner">{error}</div>}
      <div className="pipeline-layout">
        <section className="pipeline-column">
          <div className="section-label">
            Pipeline architecture <span>5 execution stages</span>
          </div>
          <div className="pipeline-track">
            <PipelineStage
              id="erp"
              label="Fake ERP"
              detail={`${source.totalCount} records available`}
              icon={<Database size={19} />}
              active={stage === 'erp'}
              onClick={setStage}
            />
            <PipelineConnector />
            <PipelineStage
              id="extract"
              label="Extract"
              detail={run ? `${run.recordsExtracted} records extracted` : 'Not run yet'}
              icon={<ArrowDown size={19} />}
              active={stage === 'extract'}
              onClick={setStage}
            />
            <PipelineConnector />
            <PipelineStage
              id="staging"
              label="Staging"
              detail={run ? `${staging.totalCount} records captured` : 'Not run yet'}
              icon={<Layers3 size={19} />}
              active={stage === 'staging'}
              onClick={setStage}
            />
            <PipelineConnector />
            <PipelineStage
              id="transform"
              label="Transform"
              detail={run ? `${run.recordsTransformed} records transformed` : 'Not run yet'}
              icon={<RefreshCw size={19} />}
              active={stage === 'transform'}
              onClick={setStage}
            />
            <PipelineConnector />
            <PipelineStage
              id="validate"
              label="Validate"
              detail={
                run ? `${run.recordsValidated} / ${run.recordsExtracted} valid` : 'Not run yet'
              }
              icon={<FileCheck2 size={19} />}
              active={stage === 'validate'}
              onClick={setStage}
            />
            <PipelineConnector />
            <PipelineStage
              id="load"
              label="Load"
              detail={run ? `${run.recordsLoaded} records loaded` : 'Not run yet'}
              icon={<Database size={19} />}
              active={stage === 'load'}
              onClick={setStage}
            />
            <PipelineConnector />
            <PipelineStage
              id="analytical"
              label="Analytical records"
              detail={`FactGL · ${analyticalRecords.totalCount} rows`}
              icon={<Layers3 size={19} />}
              active={stage === 'analytical'}
              onClick={setStage}
            />
          </div>
          {run && <PipelineExecutionCard run={run} />}
        </section>
        <section className="detail-column">
          <StagePanel
            stage={stage}
            run={run}
            source={source.items}
            staging={staging.items}
            transformations={transformations.items}
            validation={validation}
            errors={run?.errors ?? []}
            scenario={scenario}
            onScenarioChange={selectScenario}
            analyticalRecords={analyticalRecords.items}
            analyticalSummary={analyticalRecords}
            sourcePagination={{ ...source, onPageChange: (page) => void loadSourcePage(page) }}
            stagingPagination={{ ...staging, onPageChange: (page) => void loadStagingPage(page) }}
            transformationPagination={{ ...transformations, onPageChange: (page) => void loadTransformationPage(page) }}
            analyticalPagination={{ ...analyticalRecords, onPageChange: (page) => void loadAnalyticalPage(page) }}
            onSourcePageChange={(page) => void loadSourcePage(page)}
            onStagingPageChange={(page) => void loadStagingPage(page)}
            onTransformationPageChange={(page) => void loadTransformationPage(page)}
            onAnalyticalPageChange={(page) => void loadAnalyticalPage(page)}
          />
        </section>
      </div>
      {resetConfirmOpen && (
        <div className="modal-backdrop" role="presentation">
          <section className="confirm-dialog" role="dialog" aria-modal="true" aria-labelledby="reset-title">
            <p className="eyebrow">DEVELOPMENT / POC ACTION</p>
            <h2 id="reset-title">Reset pipeline data?</h2>
            <p>
              This will delete pipeline runs, staging records, and analytical records (FactGL).
              Fake ERP source data and analytical dimensions will not be changed.
            </p>
            <div className="dialog-actions">
              <button className="secondary-button" onClick={() => setResetConfirmOpen(false)} disabled={resetting}>
                Cancel
              </button>
              <button className="danger-button" onClick={reset} disabled={resetting}>
                <RotateCcw size={16} />
                {resetting ? 'Resetting...' : 'Reset pipeline'}
              </button>
            </div>
          </section>
        </div>
      )}
    </main>
  );
}
