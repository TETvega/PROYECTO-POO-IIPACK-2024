import { Navigate, Route, Routes } from "react-router-dom";
import { Footer, Header } from "../../../shared/components";
import { CatalagoProducts, FormEditEventPage, FormEventPage, HomePage, PageNotFound } from "../pages";
import { MyEvents } from "../pages/MyEvents";

export const WebRouter = () => {
  return (
    <div>
      <Header /> {/* Header ahora incluye el SideBar2 */}
      <div>
        <main className="flex-row">
          <div className="w-full">
            <Routes>
              <Route path="/reservation" element={<FormEventPage />} />
              <Route path="/not-found" element={<PageNotFound />} />
              <Route path="/my-events" element={<MyEvents />} />
              <Route path="/products" element={<CatalagoProducts />} />
              <Route path="/my-event/edit/:id" element={<FormEditEventPage/>} />
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
