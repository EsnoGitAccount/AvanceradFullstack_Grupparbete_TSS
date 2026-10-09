import { Route, Routes } from 'react-router'

import HomePage from './pages/home-page/HomePage'
import TestPage from './test-pages/TestPage'

function App() {
  return (
    <Routes>
      <Route path="/" element={null} />
      <Route path="/test" element={<TestPage />} />
      <Route path="/homepage" element={<HomePage />} />
    </Routes>
  );
}

export default App
