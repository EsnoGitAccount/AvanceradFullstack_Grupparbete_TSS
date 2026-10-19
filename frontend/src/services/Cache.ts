export async function getCacheData<T>(
    key: string,
    fetchData: () => Promise<T>
    ): Promise<T> {
        const cachedKey = `cache_${key}`;
        const cachedData = localStorage.getItem(cachedKey);

    if (cachedData) {
        try {
            const { data, expiresAt } = JSON.parse(cachedData);

            if (Date.now() < expiresAt) {
                return data as T;
            }
        } catch (error) {
            console.error("Error parsing cached data:", error);
        }

        localStorage.removeItem(cachedKey);
    }

    const data: T = await fetchData();

    const midnight = new Date();
    midnight.setUTCHours(24, 0, 0, 0);

    const expiresAt = midnight.getTime();
    
    try {
        localStorage.setItem(cachedKey, JSON.stringify({ data, expiresAt }));
    } catch (error) {
        console.error("Error caching data:", error);
    }

    return data;
}