import React, { useState } from "react";
import styles from "./Navigation.module.scss";
import { animated } from "@react-spring/web";
import { useAppDispatch, useAppSelector } from "../../../hooks/reduxHooks";
import { makeMenuInvisible, makeMenuVisible } from "../../../store/menu";
import { Menu } from "./menu/Menu";
import { Link } from "react-router-dom";

export const Navigation: React.FC = () => {
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
        <a>Login</a>
        <a>Register</a>
      </div>
    </nav>
  );
};
