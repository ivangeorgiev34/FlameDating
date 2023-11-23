import React from "react";
import styles from "./Unauthorized.module.scss";
import { Link } from "react-router-dom";

export const Unauthorized: React.FC = () => {
  return (
    <div className={styles.unauthorizedWrapper}>
      <div className={styles.unauthorizedCard}>
        <h2 className={styles.errorTitle}>401 Unauthorized</h2>
        <p className={styles.errorDescription}>
          You are not allowed to access this resource
        </p>
        <Link to={"/"}>Back to home</Link>
      </div>
    </div>
  );
};
