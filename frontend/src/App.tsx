import { Outlet, Route, Routes } from 'react-router'
import LeaderboardPage from './pages/leaderboard-page/LeaderboardPage'
import HomePage from './pages/home-page/HomePage'
import ErrorTestPage from './pages/error-test-page/ErrorTestPage';
import NotFoundPage from './pages/not-found-page/NotFoundPage';
import LoginPage from './pages/login-page/LoginPage';
import GamePage from './pages/game-page/gamePage';
import ProfilePage from "./pages/profile-page/ProfilePage";
import ProtectedRoute from './protected-route/ProtectedRoute';
import RegisterPage from './pages/register-page/RegisterPage';
import SiteHeader from './components/site-header/SiteHeader'
import SiteFooter from './components/site-footer/SiteFooter'
import TestTrainLoading from './pages/test-train-loading/TestTrainLoading'
import './App.css'

function SiteLayout() {
  return (
    <div className="site-page">
      <SiteHeader />
      <main className="site-page__main">
        <Outlet />
      </main>
      <SiteFooter />
    </div>
  )
}

function App() {
  return (
    <Routes>
      {/* With header/footer */}
      <Route element={<SiteLayout />}>
        <Route path="/" element={<HomePage />} />
        <Route path="/homepage" element={<HomePage />} />
        <Route path="/leaderboard" element={<LeaderboardPage />} />
        <Route path="/game" element={<GamePage />} />
        <Route path="/login" element={<LoginPage />} />
        <Route path="/register" element={<RegisterPage />} />
        <Route path="/profile" element={<ProtectedRoute><ProfilePage /></ProtectedRoute>} />
      </Route>

      {/* Without header/footer */}
      <Route path="/test-train-loading" element={<TestTrainLoading />} />
      <Route path="/errortesting" element={<ErrorTestPage />} />
      <Route path="/*" element={<NotFoundPage />} />
    </Routes>
  );
}

export default App
