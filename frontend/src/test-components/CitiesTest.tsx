import axios from 'axios'
import { useState } from 'react';

type City = { cityId: number; name: string };

function CitiesTest() {
    const [cities, setCities] = useState<City[]>([])
    const [isLoading, setIsLoading] = useState(false)
    const [error, setError] = useState<string | null>(null)

    const getCities = async () => {
      setIsLoading(true)
      setError(null)

    try {
        const response = await axios.get<City[]>('/api/cities')
        setCities(response.data)
    } 

    catch (requestError) {
        if (axios.isAxiosError(requestError)){
            setError(requestError.message)
        }

        else {
            setError('unexpected error, ni är fucked')
        }
    }

    finally {
        setIsLoading(false)
    }
}

  return (
    <section>
      <h2>Hämta städer API-test</h2>

      <button type="button" onClick={getCities} disabled={isLoading}>
        {isLoading ? 'Laddar...' : 'Hämta alla städer'}
      </button>

      {error && <p>Error: {error}</p>}

      <ul>
        {cities.map((city) =>(<li key={city.cityId}>{city.name}</li>
        ))}
      </ul>
    </section>
  )
}

export default CitiesTest