import { Route, Routes } from 'react-router'
import LeaderboardPage from './pages/leaderboard-page/LeaderboardPage'
import HomePage from './pages/home-page/HomePage'
import TestPage from './test-pages/TestPage'
import ErrorTestPage from './pages/error-test-page/ErrorTestPage';
import NotFoundPage from './pages/not-found-page/NotFoundPage';
import QuestionDestination from './components/game-components/question-destination/QuestionDestination';
import StartGameTest from './test-components/start-game-test/StartGameTest';

function App() {
  return (
    <Routes>
      <Route path="/" element={null} />
      <Route path="/test" element={<TestPage />} />
      <Route path="/homepage" element={<HomePage />} />
      <Route path="/leaderboard" element={<LeaderboardPage />} />
      <Route path="/destination-question" element={<QuestionDestination />} />
      <Route path="/errortesting" element={<ErrorTestPage />} />
      <Route path="/testgame" element={<StartGameTest />} />
      <Route path='/*' element={<NotFoundPage />} />
    </Routes>
  );
}

export default App
