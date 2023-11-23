import React from "react";
import { useAppSelector } from "../../hooks/reduxHooks";
import { Navigate, Outlet } from "react-router-dom";

export const PublicRouteGuard: React.FC = () => {
  const { expires } = useAppSelector((state) => state.auth);

  if (expires !== null) {
    return <Navigate to={"/"} />;
  } else if (new Date(expires!).getTime() >= Date.now()) {
    return <Navigate to={"/"} />;
  }

  return <Outlet />;
};
