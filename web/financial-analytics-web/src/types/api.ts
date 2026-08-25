export type Source = {
  sourceTransactionId: string;
  transactionDate: string;
  sourceAccountCode: string;
  sourceAccountName: string;
  sourceEntityCode: string;
  amount: number;
  currencyCode: string;
  description: string | null;
};
export type Staging = Source & {
  pipelineRunId: number;
};
export type Transformation = Source & {
  canonicalAccountCode: string | null;
  canonicalAccountName: string | null;
  accountCategory: string | null;
  accountKey: number | null;
  entityName: string | null;
  entityKey: number | null;
  dateKey: number | null;
  currencyName: string | null;
  currencyKey: number | null;
};
export type AnalyticalRecord = {
  sourceSystem: string;
  sourceTransactionId: string;
  transactionDate: string;
  accountCode: string;
  accountName: string;
  accountCategory: string;
  entityCode: string;
  currencyCode: string;
  amount: number;
};
export type Run = {
  pipelineRunId: number;
  status: string;
  startedAt: string;
  completedAt: string | null;
  recordsExtracted: number;
  recordsTransformed: number;
  recordsValidated: number;
  recordsLoaded: number;
  recordsInserted: number;
  recordsAlreadyExisting: number;
  recordsFailed: number;
  validation?: Validation | null;
  errors: PipelineError[];
};
export const pipelineScenarioOptions = [
  {
    value: 'happy',
    label: 'Happy Path',
    description: 'Valid source data; the complete pipeline succeeds.',
  },
  {
    value: 'transform-failure',
    label: 'Transform Failure',
    description: 'A source record cannot be mapped to the analytical model.',
  },
  {
    value: 'validation-failure',
    label: 'Validation Failure',
    description: 'Source records transform successfully but fail an integrity check.',
  },
] as const;
export type PipelineScenario = (typeof pipelineScenarioOptions)[number]['value'];
export type Validation = {
  recordsReceived: number;
  accountsMapped: number;
  validDates: number;
  transformationErrors: number;
  duplicates: number;
  invalidAmounts: number;
  reconciliationByCurrency: CurrencyReconciliation[];
  reconciliationPassed: boolean;
  isValid: boolean;
  errors: PipelineError[];
};
export type CurrencyReconciliation = {
  currency: string;
  sourceTotal: number;
  transformedTotal: number;
  difference: number;
};
export type PipelineError = {
  phase: string;
  code: string;
  sourceTransactionId: string | null;
  message: string;
};
export type Page<T> = {
  items: T[];
  page: number;
  pageSize: number;
  totalCount: number;
  totalPages: number;
};
export type AnalyticalPage = Page<AnalyticalRecord> & {
  accountCount: number;
  entityCount: number;
  dateCount: number;
  currencyCount: number;
};
export type ReportLine = { account: string; amount: number };
export type ReportSection = { total: number; lines: ReportLine[] };
export type Report = {
  period: { from: string; to: string };
  entity: string | null;
  currencyCode: string | null;
  revenue: ReportSection;
  cogs: ReportSection;
  grossProfit: number;
  grossMargin: number;
  operatingExpenses: ReportSection;
  netIncome: number;
};
