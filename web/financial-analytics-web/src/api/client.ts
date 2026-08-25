export const baseUrl =
  (import.meta.env.VITE_API_BASE_URL as string | undefined)?.replace(/\/$/, '') ??
  'http://localhost:5080';

export async function request<T>(
  path: string,
  init?: RequestInit,
  acceptedStatuses: number[] = [],
): Promise<T> {
  let response: Response;
  try {
    response = await fetch(`${baseUrl}${path}`, init);
  } catch {
    throw new Error('The API is unavailable. Check that the backend is running.');
  }
  if (!response.ok && !acceptedStatuses.includes(response.status)) {
    if (response.status === 404)
      throw new Error('Not found. Run the pipeline to create a dataset.');
    if (response.status === 400)
      throw new Error((await response.text()) || 'The request is invalid.');
    throw new Error('The API could not complete the request.');
  }
  return (await response.json()) as T;
}
