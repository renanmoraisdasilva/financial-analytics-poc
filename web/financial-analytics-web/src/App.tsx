import { useState } from 'react';
import { Header } from './components/layout/Header';
import { FinancialReportPage } from './pages/FinancialReportPage';
import { PipelinePage } from './pages/PipelinePage';

function App() {
  const [view, setView] = useState<'pipeline' | 'report'>('pipeline');
  return (
    <>
      <Header view={view} setView={setView} />
      {view === 'pipeline' ? <PipelinePage /> : <FinancialReportPage />}
    </>
  );
}

export default App;
