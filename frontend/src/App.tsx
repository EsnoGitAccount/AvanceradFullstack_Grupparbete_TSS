import { Route, Routes } from 'react-router'
import LeaderboardPage from './pages/leaderboard-page/LeaderboardPage'
import HomePage from './pages/home-page/HomePage'
import TestPage from './test-pages/TestPage'

function App() {
  return (
    <Routes>
      <Route path="/" element={null} />
      <Route path="/test" element={<TestPage />} />
      <Route path="/homepage" element={<HomePage />} />
      <Route path="/leaderboard" element={<LeaderboardPage />} />
    </Routes>
  );
}

export default App
