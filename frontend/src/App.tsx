import { Route, Routes } from 'react-router'
import LeaderboardPage from './pages/leaderboard-page/LeaderboardPage'
import HomePage from './pages/home-page/HomePage'
import ErrorTestPage from './pages/error-test-page/ErrorTestPage';
import NotFoundPage from './pages/not-found-page/NotFoundPage';
import LoginPage from './pages/login-page/LoginPage';
import GamePage from './pages/game-page/gamePage';
import ProfilePage from "./pages/profile-page/ProfilePage";
import ProtectedRoute from './protected-route/ProtectedRoute';

function App() {
  return (
    <Routes>
      <Route path="/" element={<GamePage />} />
      <Route path="/homepage" element={<HomePage />} />
      <Route path="/leaderboard" element={<LeaderboardPage />} />
      <Route path="/errortesting" element={<ErrorTestPage />} />
      <Route path="/game" element={<GamePage />} />
      <Route path='/*' element={<NotFoundPage />} />
      <Route path="/login" element={<LoginPage />} />

      <Route path="/profile" element={<ProtectedRoute><ProfilePage /></ProtectedRoute>} />
    </Routes>
  );
}

export default App
