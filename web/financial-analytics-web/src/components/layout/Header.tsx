import { Menu } from 'lucide-react';
import { baseUrl } from '../../api/client';

export function Header({
  view,
  setView,
}: {
  view: string;
  setView: (view: 'pipeline' | 'report') => void;
}) {
  return (
    <header className="topbar">
      <div className="topbar-inner">
        <div className="brand">
          <span className="brand-mark">N</span>
          <span>
            Northstar <strong>Analytics</strong>
          </span>
        </div>
        <nav>
          <button
            className={view === 'pipeline' ? 'nav-active' : ''}
            onClick={() => setView('pipeline')}
          >
            Data Pipeline
          </button>
          <button
            className={view === 'report' ? 'nav-active' : ''}
            onClick={() => setView('report')}
          >
            Financial Report
          </button>
          <a className="nav-link" href={`${baseUrl}/swagger`} target="_blank" rel="noreferrer">
            Swagger
          </a>
        </nav>
        <div className="top-actions">
          <span className="connection-dot" /> Live API{' '}
          <button className="icon-button" aria-label="Menu">
            <Menu size={18} />
          </button>
        </div>
      </div>
    </header>
  );
}
