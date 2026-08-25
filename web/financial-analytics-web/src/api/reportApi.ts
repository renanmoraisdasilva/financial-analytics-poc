import { request } from './client';
import type { Report } from '../types/api';

export const reportApi = {
  financial: (from: string, to: string, entity: string) =>
    request<Report>(
      `/api/reports/financial?from=${from}&to=${to}${entity ? `&entity=${encodeURIComponent(entity)}` : ''}`,
    ),
};
