import React from "react";
import styles from "./MatchPopup.module.scss";

export const MatchPopup: React.FC = () => {
  return (
    <div className={styles.popupWrapper}>
      <div className={styles.popupCard}></div>
    </div>
  );
};
