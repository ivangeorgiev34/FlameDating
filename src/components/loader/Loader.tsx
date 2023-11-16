import styles from "./Loader.module.scss";

export const Loader: React.FC = () => {
  return (
    <div>
      <div className={styles.overlay}>
        <div className={styles.rhombus}>
          <div className={styles.circle1}></div>
          <div className={styles.circle2}></div>
        </div>
      </div>
    </div>
  );
};
