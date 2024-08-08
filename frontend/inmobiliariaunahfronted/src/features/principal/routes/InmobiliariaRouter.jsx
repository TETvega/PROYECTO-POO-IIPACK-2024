import { LandingPage } from "../pages/LandingPage";
import { Navigate, Route, Routes } from 'react-router-dom'
export const InmobiliariaRouter = () => {
  return (
    <div>
         <Routes>
            <Route path= '' element={<LandingPage />} />  
            <Route path= '/*' element={<Navigate to="/home" />} />
            </Routes>
    </div>
  );
}
