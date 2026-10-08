import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.tsx'
import TestGame from './test-components/TestGame.tsx'

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <App />
    <TestGame city="Stockholm" />
  </StrictMode>,
)
