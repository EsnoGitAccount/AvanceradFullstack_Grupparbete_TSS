import api from "./api.ts"

export const get400Error = async () => {
    const response = await api.get("/api/ErrorTestControllers/400")
    if(response.status === 200){
        return "No fail";
    }

    return response.data;
}

export const get404Error = async () => {
    const response = await api.get("/api/ErrorTestControllers/404")
    if(response.status === 200){
        return "No fail";
    }

    return response.data;
}

export const get500Error = async () => {
    const response = await api.get("/api/ErrorTestControllers/500")
    if(response.status === 200){
        return "No fail";
    }

    return response.data;
}