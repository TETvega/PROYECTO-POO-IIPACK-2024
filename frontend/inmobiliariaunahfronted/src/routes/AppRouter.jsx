import {PrincipalRouter} from '../features/principal/routes/PrincipalRouter'
import { Route, Routes } from 'react-router-dom'

export const AppRouter = () => {
  return (
    <Routes>
        <Route path="*" element={<PrincipalRouter />} />
      </Routes>
  )
}