import { Route, Routes } from 'react-router-dom'
import { WebRouter } from '../features/Website/routes/WebRouter'

export const AppRouter = () => {
  return (
    <Routes>
        <Route path="*" element={<WebRouter />} />
      </Routes>
  )
}