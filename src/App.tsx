import React from "react";
import "./App.css";
import { Loader } from "./components/loader/Loader";
import { Navigation } from "./components/layout/navigation/Navigation";
import { Menu } from "./components/layout/navigation/menu/Menu";
import { useAppSelector } from "./hooks/reduxHooks";
import { Route, Routes } from "react-router-dom";
import { Home } from "./pages/Home/Home";
import { Login } from "./pages/Login/Login";
import { PublicRouteGuard } from "./guards/PublicRouteGuard/PublicRouteGuard";
import { PrivateRouteGuard } from "./guards/PrivateRouteGuard/PrivateRouteGuard";
import { Matches } from "./pages/Matches/Matches";
import { Unauthorized } from "./pages/Unauthorized/Unauthorized";
import { InternalServerError } from "./pages/InternalServerError/InternalServerError";

function App() {
  const { isVisible } = useAppSelector((state) => state.menu);
  const { isLoading } = useAppSelector((state) => state.loader);

  return (
    <React.Fragment>
      {isLoading === true ? <Loader /> : <></>}
      <Navigation />
      <main>
        {isVisible === true ? <Menu /> : <></>}
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/unauthorized" element={<Unauthorized />} />
          <Route
            path="/internal-server-error"
            element={<InternalServerError />}
          />
          <Route element={<PublicRouteGuard />}>
            <Route path="/login" element={<Login />} />
          </Route>
          <Route element={<PrivateRouteGuard />}>
            <Route path="/matches" element={<Matches />} />
          </Route>
        </Routes>
      </main>
    </React.Fragment>
  );
}

export default App;
