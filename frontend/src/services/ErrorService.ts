import api from "./api.ts"

export const get400Error = async () => {
    const response = await api.get("/api/errortest/400")
    if(response.status === 200){
        return "No fail";
    }

    return response.data;
}