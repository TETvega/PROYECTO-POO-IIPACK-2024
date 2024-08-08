import { Route, Routes } from 'react-router-dom'
import {InmobiliariaRouter} from '../features/principal/routes/InmobiliariaRouter'
export const AppRouter = () => {
  return (
    <Routes>
            <Route path="*" element={<InmobiliariaRouter />} />
      </Routes>
  )
}
