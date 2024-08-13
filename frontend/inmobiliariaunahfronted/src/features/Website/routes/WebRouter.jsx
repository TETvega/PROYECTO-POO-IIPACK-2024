import { Navigate, Route, Routes } from "react-router-dom";
import { CatalogPage, HomePage } from "../pages";
import { Footer, NavBar } from "../components";

export const WebRouter = () => {
  return (
    <div className="overflow-x-hidden bg-gray-100 min-h-screen flex flex-col">
      <NavBar />
      <main className="flex-grow">
        <Routes>
          <Route path="/catalog" element={<CatalogPage/>} />
          <Route path="/home" element={<HomePage />} />
          <Route path="/*" element={<Navigate to={"/home"} />} />
        </Routes>
      </main>
      <Footer />
    </div>
  );
};
