import axios from 'axios'
import { useState } from 'react'

import { Badge } from '@/components/ui/Badge'
import { Button } from '@/components/ui/Button'
import {
  Card,
  CardAction,
  CardContent,
  CardHeader,
  CardTitle,
} from '@/components/ui/Card'

import './CitiesTest.css'

type City = {
  cityId: number
  name: string
}

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
    } catch (requestError) {
      if (axios.isAxiosError(requestError)) {
        setError(requestError.message)
      } else {
        setError('Ett oväntat fel inträffade.')
      }
    } finally {
      setIsLoading(false)
    }
  }

  return (
    <Card className="cities-test">
      <CardHeader className="cities-test__header">
        <CardTitle>
          <h2 className="cities-test__title">Städer API-test</h2>
        </CardTitle>
        <CardAction>
          <Badge variant="secondary">
            {cities.length} {cities.length === 1 ? 'stad' : 'städer'}
          </Badge>
        </CardAction>
      </CardHeader>

      <CardContent className="cities-test__content">
        <Button type="button" onClick={getCities} disabled={isLoading}>
          {isLoading ? 'Laddar...' : 'Hämta alla städer'}
        </Button>

        {error && (
          <p className="cities-test__error" role="alert">
            {error}
          </p>
        )}

        {cities.length > 0 && (
          <ul className="cities-test__list">
            {cities.map((city) => (
              <li key={city.cityId}>{city.name}</li>
            ))}
          </ul>
        )}
      </CardContent>
    </Card>
  )
}

export default CitiesTest
