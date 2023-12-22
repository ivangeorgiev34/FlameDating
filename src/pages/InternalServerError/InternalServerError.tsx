import React from "react";
import styles from "./InternalServerError.module.scss";
import { Link } from "react-router-dom";

export const InternalServerError: React.FC = () => {
  return (
    <div className={styles.errorWrapper}>
      <div className={styles.errorCard}>
        <h2 className={styles.errorTitle}>500 Internal Server Error</h2>
        <p className={styles.errorDescription}>
          An unexpected error in the server has occured
        </p>
        <Link to={"/"}>Back to home</Link>
      </div>
    </div>
  );
};
