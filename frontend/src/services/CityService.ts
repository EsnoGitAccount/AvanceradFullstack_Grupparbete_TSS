import api from "./api"
import type { City } from "../models/City";

export const getAllCities = async (): Promise<City[]> => {
    const response = await api.get<City[]>("api/cities")
    return response.data;
}