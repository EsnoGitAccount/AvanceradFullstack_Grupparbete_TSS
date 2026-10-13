import { useState, useEffect } from "react"
import { get400Error } from "../../services/ErrorService"
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

            console.log("Vi har hämtat utan fel")
        }
        catch(error: unknown){
            const message = axios.isAxiosError(error)
            ? error.message
            : "Det var ett fel men meddelandet kunde inte läsas"

            setErrors((previousErrors) => [
                ...previousErrors,
                message
            ])

            console.log("Vi är i catch")
        }
    }

    // useEffect (() => {
    //     tryErrors();
    // }, [])

    return(
        <>
            {errors.length == 0 && <div>Det finns inga fel</div> }
            {errors.map((error) =>(
                <p>Test result: {error}</p>
            ))}

            <Button onClick={() => {setErrors([]); console.log("Tryck på knapp"); tryErrors();}}>Test again</Button>
        </>
    )
}