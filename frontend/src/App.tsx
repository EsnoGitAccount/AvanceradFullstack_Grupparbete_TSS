import { Route, Routes } from 'react-router'

import HomePage from './pages/home-page/HomePage'
import TestPage from './test-pages/TestPage'
import ErrorTestPage from './pages/error-test-page/ErrorTestPage';
import NotFoundPage from './pages/not-found-page/NotFoundPage';

function App() {
  return (
    <Routes>
      <Route path="/" element={null} />
      <Route path="/test" element={<TestPage />} />
      <Route path="/homepage" element={<HomePage />} />
      <Route path="/errortesting" element={<ErrorTestPage />} />
      <Route path='/*' element={<NotFoundPage />} />
    </Routes>
  );
}

export default App
