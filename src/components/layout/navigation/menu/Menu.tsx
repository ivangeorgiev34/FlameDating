import React, { useEffect } from "react";
import { animated, useSpring, useSpringValue } from "@react-spring/web";
import { useAppDispatch, useAppSelector } from "../../../../hooks/reduxHooks";
import styles from "./Menu.module.scss";
import { Link } from "react-router-dom";
import { makeMenuInvisible } from "../../../../store/menu";

export const Menu: React.FC = () => {
  const { isVisible } = useAppSelector((state) => state.menu);
  const dispatch = useAppDispatch();

  const [props, api] = useSpring(() => ({
    from: {
      x: -300,
    },
    to: {
      x: 0,
    },
    config: {
      duration: 200,
    },
  }));

  useEffect(() => {
    api.start({
      from: {
        x: -300,
      },
      to: {
        x: 0,
      },
      config: {
        duration: 200,
      },
    });
  }, []);

  return (
    <animated.div style={props} className={styles.menu}>
      <ul className={styles.menuItems}>
        <li className={styles.menuItem}>
          <Link
            className={styles.menuBtn}
            to={"/"}
            onClick={() => dispatch(makeMenuInvisible())}
          >
            Home
          </Link>
        </li>
        <li className={styles.menuItem}>
          <Link
            className={styles.menuBtn}
            to={"/matches"}
            onClick={() => dispatch(makeMenuInvisible())}
          >
            Matches
          </Link>
        </li>
        <li className={styles.menuItem}>
          <Link
            className={styles.menuBtn}
            to={"/chats"}
            onClick={() => dispatch(makeMenuInvisible())}
          >
            Chats
          </Link>
        </li>
      </ul>
    </animated.div>
  );
};
