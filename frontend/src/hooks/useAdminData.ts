import { useEffect, useState } from "react";

export function useAdminData<T>(load: () => Promise<T[]>) {
  const [data, setData] = useState<T[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [attempt, setAttempt] = useState(0);

  useEffect(() => {
    let active = true;

    async function fetchData() {
      setLoading(true);
      setError(null);
      try {
        const result = await load();
        if (active) setData(result);
      } catch (error) {
        if (active) {
          setError(error instanceof Error ? error.message : "Kunde inte ladda data.");
        }
      } finally {
        if (active) setLoading(false);
      }
    }

    void fetchData();
    return () => { active = false; };
  }, [load, attempt]);

  return { data, setData, loading, error, retry: () => setAttempt((value) => value + 1) };
}
