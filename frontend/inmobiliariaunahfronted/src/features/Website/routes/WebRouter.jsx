import { Navigate, Route, Routes } from "react-router-dom";
import { Footer, Header, SideBar2 } from "../../../shared/components";
import { HomePage } from "../pages/HomePage";

export const WebRouter = () => {
  return (
    <div>
      <SideBar2 />
      <div>
        <main className="flex-row ">
          <Header />
          <div className="w-full">
            <Routes>
              <Route path="/home" element={<HomePage />} />
              <Route path="/*" element={<Navigate to={"/home"} />} />
            </Routes>
          </div>
        </main>
        <Footer />
      </div>
    </div>
  );
};
