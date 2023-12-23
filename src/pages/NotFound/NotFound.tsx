import React from "react";
import styles from "./NotFound.module.scss";
import { Link } from "react-router-dom";

export const NotFound: React.FC = () => {
  return (
    <div className={styles.errorWrapper}>
      <div className={styles.errorCard}>
        <h2 className={styles.errorTitle}>404 Not Found</h2>
        <p className={styles.errorDescription}>The resource cannot be found</p>
        <Link to={"/"}>Back to home</Link>
      </div>
    </div>
  );
};
