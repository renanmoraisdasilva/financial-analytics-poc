import { useEffect, useState } from 'react';
import { LoaderCircle } from 'lucide-react';
import { reportApi } from '../api/reportApi';
import type { Report } from '../types/api';
import { IncomeStatement } from '../components/report/IncomeStatement';
import { ReportFilters } from '../components/report/ReportFilters';
import { ReportSummary } from '../components/report/ReportSummary';

export function FinancialReportPage() {
  const [report, setReport] = useState<Report | null>(null);
  const [from, setFrom] = useState('2026-01-01');
  const [to, setTo] = useState('2026-03-31');
  const [entity, setEntity] = useState('US');
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  useEffect(() => {
    let cancelled = false;
    const loadReport = async () => {
      setLoading(true);
      setError(null);
      try {
        const nextReport = await reportApi.financial(from, to, entity);
        if (!cancelled) {
          setReport(nextReport);
        }
      } catch (error) {
        if (!cancelled) {
          setError(error instanceof Error ? error.message : 'The report could not be loaded.');
        }
      } finally {
        if (!cancelled) {
          setLoading(false);
        }
      }
    };
    void loadReport();
    return () => {
      cancelled = true;
    };
  }, [from, to, entity]);
  return (
    <main className="page report-page">
      <div className="page-heading">
        <div>
          <p className="eyebrow">REPORTING / MANAGEMENT VIEW</p>
          <h1>Financial Report</h1>
          <p className="lede">A reconciled view of analytical performance.</p>
        </div>
        <ReportFilters
          from={from}
          to={to}
          entity={entity}
          setFrom={setFrom}
          setTo={setTo}
          setEntity={setEntity}
        />
      </div>
      {loading && (
        <div className="loading-state">
          <LoaderCircle size={18} className="spin" /> Loading report...
        </div>
      )}
      {error && <div className="error-banner">{error}</div>}
      {report && !loading && (
        <>
          <ReportSummary report={report} />
          <IncomeStatement report={report} />
        </>
      )}
    </main>
  );
}
