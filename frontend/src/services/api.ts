import axios from "axios";

const api = axios.create({
    baseURL: import.meta.env.VITE_API_BASE_URL,
    withCredentials: true,
    withXSRFToken: true,
    xsrfCookieName: 'XSRF-TOKEN',
    xsrfHeaderName: 'X-XSRF-TOKEN',
});

api.interceptors.response.use(
    (response) => response,
    (error) => {
        const status = error.response?.status;
        const detail = error.response?.data.detail;

        if (status === 400) {
            error.message =
                detail || "Kunde inte hantera förfrågan."
        }

        if (status === 404) {
            error.message =
                detail || "Resursen kunde inte hittas."
        }

        if (status === 409) {
            error.message =
                detail || "Du har redan spelat idag."
        }

        if (status === 500) {
            error.message =
                detail || "Ett oväntat serverfel inträffade."
        }

        return Promise.reject(error);
    }
);

export default api;