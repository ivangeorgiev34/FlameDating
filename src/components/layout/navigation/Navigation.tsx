import React, { useState } from "react";
import styles from "./Navigation.module.scss";
import { animated } from "@react-spring/web";
import { useAppDispatch, useAppSelector } from "../../../hooks/reduxHooks";
import { makeMenuInvisible, makeMenuVisible } from "../../../store/menu";
import { Menu } from "./menu/Menu";
import { Link, useNavigate } from "react-router-dom";
import { logout } from "../../../store/auth";
import { removeInterests } from "../../../store/interests";

export const Navigation: React.FC = () => {
  const navigate = useNavigate();
  const dispatch = useAppDispatch();
  const { isVisible } = useAppSelector((state) => state.menu);
  const { token } = useAppSelector((state) => state.auth);

  return (
    <nav className={styles.navBar}>
      <div className={styles.menuLogoWrapper}>
        <Link to={"/"} className={styles.logo}>
          <img src="flame-dating-logo.png" alt="flame-dating-logo" />
          <span>FlameDating</span>
        </Link>
        {token !== null ? (
          <button
            className={styles.menuBtn}
            onClick={() => {
              isVisible === true
                ? dispatch(makeMenuInvisible())
                : dispatch(makeMenuVisible());
            }}
          >
            {isVisible === true ? (
              <i
                className={
                  "fa-regular fa-circle-xmark fa-spin fa-flip-horizontal"
                }
              ></i>
            ) : (
              <i className={"fa-solid fa-bars"}></i>
            )}
          </button>
        ) : (
          <></>
        )}
      </div>
      <div className={styles.btnsContainer}>
        {token === null ? (
          <>
            <Link to={"/login"} className={styles.loginBtn}>
              Login
            </Link>
            <Link to={"/register"} className={styles.registerBtn}>
              Register
            </Link>
          </>
        ) : (
          <Link
            className={styles.logoutBtn}
            onClick={() => {
              dispatch(removeInterests());
              dispatch(logout());
            }}
            to={"/"}
          >
            Logout
          </Link>
        )}
      </div>
    </nav>
  );
};
