import CitiesTest from '@/test-components/cities-test/CitiesTest'
import TestGame from '@/test-components/test-game/TestGame'

import './TestPage.css'

function TestPage() {
  return (
    <main className="test-page">
      <CitiesTest />
      <TestGame city="Stockholm" />
    </main>
  )
}

export default TestPage
