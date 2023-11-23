import React, { useEffect, useState } from "react";
import { useAppSelector } from "../../hooks/reduxHooks";
import { useNavigate } from "react-router-dom";
import { GuestHome } from "../GuestHome/GuestHome";

export const Home: React.FC = () => {
  const { token } = useAppSelector((state) => state.auth);

  return (
    <React.Fragment>
      {token !== null ? <div>rgherger</div> : <GuestHome />}
    </React.Fragment>
  );
};
