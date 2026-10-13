import { useState } from "react"
import { get400Error, get404Error, get500Error } from "../../services/ErrorService"
import axios from "axios";
import { Button } from "../../components/ui/Button.tsx";

export default function ErrorTestPage(){
    const [errors, setErrors] = useState<string[]>([])

    const tryErrors = async () => {
        try{
            const response = await get400Error();
            setErrors((previousErrors) => [
                ...previousErrors,
                response,
            ]);
        }
        catch(error: unknown){
            const message = axios.isAxiosError(error)
            ? error.message
            : "Det var ett fel men meddelandet kunde inte läsas"

            setErrors((previousErrors) => [
                ...previousErrors,
                message
            ])
        }

        try{
            const response = await get404Error();
            setErrors((previousErrors) => [
                ...previousErrors,
                response,
            ]);
        }
        catch(error: unknown){
            const message = axios.isAxiosError(error)
            ? error.message
            : "Det var ett fel men meddelandet kunde inte läsas"

            setErrors((previousErrors) => [
                ...previousErrors,
                message
            ])
        }

        try{
            const response = await get500Error();
            setErrors((previousErrors) => [
                ...previousErrors,
                response,
            ]);
        }
        catch(error: unknown){
            const message = axios.isAxiosError(error)
            ? error.message
            : "Det var ett fel men meddelandet kunde inte läsas"

            setErrors((previousErrors) => [
                ...previousErrors,
                message
            ])
        }
    }

    return(
        <>
            {errors.length == 0 && <div>Det finns inga fel</div> }
            {errors.map((error) =>(
                <p key={error}>Test result: {error}</p>
            ))}

            <Button onClick={() => {setErrors([]); console.log("Tryck på knapp"); tryErrors();}}>Test again</Button>
        </>
    )
}