import React from "react";
import styles from "../../layout/footer/Footer.module.scss";
import { Link } from "react-router-dom";

export const Footer: React.FC = () => {
  return (
    <footer className={styles.footer}>
      <div>
        <Link to={"/"} className={styles.logo}>
          <img src="flame-dating-logo.png" alt="flame-dating-logo" />
          <span>FlameDating</span>
        </Link>
      </div>
      <p className={styles.copyright}>
        &copy; 2023 FlameDating | All Rights Reserved
      </p>
      <div className={styles.socialsContainer}>
        <p className={styles.followUs}>Follow us on:</p>
        <ul className={styles.socials}>
          <li>
            <a href="https://www.instagram.com/">
              <i className="fa-brands fa-instagram"></i>
            </a>
          </li>
          <li>
            <a href="https://www.facebook.com/">
              <i className="fa-brands fa-facebook-f"></i>
            </a>
          </li>
          <li>
            <a href="https://twitter.com/">
              <i className="fa-brands fa-x-twitter"></i>
            </a>
          </li>
          <li>
            <a href="https://youtube.com/">
              <i className="fa-brands fa-youtube"></i>
            </a>
          </li>
          <li>
            <a href="https://tiktok.com/">
              <i className="fa-brands fa-tiktok"></i>
            </a>
          </li>
        </ul>
      </div>
    </footer>
  );
};
