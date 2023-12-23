import React from "react";
import styles from "./BadRequest.module.scss";
import { Link } from "react-router-dom";

export const BadRequest: React.FC = () => {
  return (
    <div className={styles.errorWrapper}>
      <div className={styles.errorCard}>
        <h2 className={styles.errorTitle}>400 Bad Request</h2>
        <p className={styles.errorDescription}>Cannot proccess your request</p>
        <Link to={"/"}>Back to home</Link>
      </div>
    </div>
  );
};
