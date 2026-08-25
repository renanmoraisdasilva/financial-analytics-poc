import { request } from './client';
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

const toPage = <T,>(response: Page<T> | T[], page: number, pageSize: number): Page<T> => {
  if (!Array.isArray(response)) return response;

  return {
    items: response.slice((page - 1) * pageSize, page * pageSize),
    page,
    pageSize,
    totalCount: response.length,
    totalPages: Math.ceil(response.length / pageSize),
  };
};

export const pipelineApi = {
  runPipeline: (scenario: PipelineScenario) =>
    request<Run>(`/api/pipeline/run?scenario=${encodeURIComponent(scenario)}`, { method: 'POST' }, [422]),
  resetPipeline: () =>
    request<{ recordsDeleted: { facts: number; staging: number; pipelineRuns: number } }>(
      '/api/pipeline/reset',
      { method: 'DELETE' },
    ),
  pipelineRun: (id: number) => request<Run>(`/api/pipeline/runs/${id}`),
  sourceTransactions: (page = 1, pageSize = 25) =>
    request<Page<Source> | Source[]>(
      `/api/source/transactions?page=${page}&pageSize=${pageSize}`,
    ).then((response) => toPage(response, page, pageSize)),
  pipelineRunStaging: (id: number, page = 1, pageSize = 25) =>
    request<Page<Staging> | Staging[]>(
      `/api/pipeline/runs/${id}/staging?page=${page}&pageSize=${pageSize}`,
    ).then((response) => toPage(response, page, pageSize)),
  pipelineRunTransformations: (id: number, page = 1, pageSize = 25) =>
    request<Page<Transformation> | Transformation[]>(
      `/api/pipeline/runs/${id}/transformations?page=${page}&pageSize=${pageSize}`,
    ).then((response) => toPage(response, page, pageSize)),
  pipelineRunValidation: (id: number) => request<Validation>(`/api/pipeline/runs/${id}/validation`),
  analyticalRecords: (page = 1, pageSize = 25) =>
    request<AnalyticalPage | AnalyticalRecord[]>(
      `/api/analytical-records?page=${page}&pageSize=${pageSize}`,
    ).then((response) => {
      if (!Array.isArray(response)) return response;
      const pageResponse = toPage(response, page, pageSize);
      return {
        ...pageResponse,
        accountCount: new Set(pageResponse.items.map((item) => item.accountCode)).size,
        entityCount: new Set(pageResponse.items.map((item) => item.entityCode)).size,
        dateCount: new Set(pageResponse.items.map((item) => item.transactionDate)).size,
        currencyCount: new Set(pageResponse.items.map((item) => item.currencyCode)).size,
      };
    }),
};
