import React, { useEffect } from "react";
import { animated, useSpring, useSpringValue } from "@react-spring/web";
import { useAppSelector } from "../../../../hooks/reduxHooks";
import styles from "./Menu.module.scss";

export const Menu: React.FC = () => {
  const { isVisible } = useAppSelector((state) => state.menu);

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
        <li className={styles.menuItem}>Home</li>
        <li className={styles.menuItem}>Matches</li>
        <li className={styles.menuItem}>Chats</li>
      </ul>
    </animated.div>
  );
};
