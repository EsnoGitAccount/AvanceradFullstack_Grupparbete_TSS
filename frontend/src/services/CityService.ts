import axios from "axios";
import type { City } from "../models/City";

const api = axios.create({
    baseURL: import.meta.env.VITE_API_BASE_URL,
    withCredentials: true,
});

export const getAllCities = async (): Promise<City[]> => {
    const response = await api.get<City[]>("api/cities")
    return response.data;
}