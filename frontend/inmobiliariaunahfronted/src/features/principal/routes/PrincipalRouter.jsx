import { Navigate, Route, Routes } from 'react-router-dom'
import { LandingPage } from '../pages';
export const PrincipalRouter = () => {
  return (
    <div >
     <div>
        <div>
          <Routes>
            <Route path= '/' element={<LandingPage />} />
            {/* <Route path= '/*' element={<Navigate to="/home" />} /> */}
          </Routes>
        </div>
     </div>

    </div>
  )
}
