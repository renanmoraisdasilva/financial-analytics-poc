import type { ReactNode } from 'react';
import { ChevronLeft, ChevronRight } from 'lucide-react';

export type DataTablePagination = {
  page: number;
  pageSize: number;
  totalCount: number;
  totalPages: number;
  onPageChange: (page: number) => void;
};

export function DataTable({
  headers,
  rows,
  pagination,
}: {
  headers: string[];
  rows: ReactNode[][];
  pagination: DataTablePagination;
}) {
  const firstRecord = pagination.totalCount === 0 ? 0 : (pagination.page - 1) * pagination.pageSize + 1;
  const lastRecord = Math.min(pagination.page * pagination.pageSize, pagination.totalCount);

  return (
    <div>
      <div className="table-wrap">
        <table>
          <thead>
            <tr>
              {headers.map((header) => (
                <th key={header}>{header}</th>
              ))}
            </tr>
          </thead>
          <tbody>
            {rows.length ? (
              rows.map((row, index) => (
                <tr key={index}>
                  {row.map((cell, cellIndex) => (
                    <td key={cellIndex}>{cell}</td>
                  ))}
                </tr>
              ))
            ) : (
              <tr>
                <td colSpan={headers.length}>No records available.</td>
              </tr>
            )}
          </tbody>
        </table>
      </div>
      <div className="table-pagination">
        <span>
          {firstRecord}-{lastRecord} of {pagination.totalCount}
        </span>
        <div>
          <button
            type="button"
            aria-label="Previous page"
            title="Previous page"
            disabled={pagination.page <= 1}
            onClick={() => pagination.onPageChange(pagination.page - 1)}
          >
            <ChevronLeft size={16} />
          </button>
          <span>Page {pagination.page} of {Math.max(pagination.totalPages, 1)}</span>
          <button
            type="button"
            aria-label="Next page"
            title="Next page"
            disabled={pagination.page >= pagination.totalPages || pagination.totalPages === 0}
            onClick={() => pagination.onPageChange(pagination.page + 1)}
          >
            <ChevronRight size={16} />
          </button>
        </div>
      </div>
    </div>
  );
}
