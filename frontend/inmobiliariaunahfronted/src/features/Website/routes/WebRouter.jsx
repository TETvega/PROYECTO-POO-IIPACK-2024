import { Navigate, Route, Routes } from "react-router-dom";
import { Footer, SideBar2 } from "../../../shared/components";
import { HomePage } from "../pages/HomePage";

export const WebRouter = () => {
  return (
    <div>
      <SideBar2 />
      <div>
        <main className="container flex justify-between mx-auto">
          <Routes>
            <Route path="/home" element={<HomePage />} />
            <Route path="/*" element={<Navigate to={"/home"} />} />
          </Routes>
        </main>
        <Footer />
      </div>
    </div>
  );
};
