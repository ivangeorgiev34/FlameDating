import React, { useEffect, useState } from "react";
import styles from "./MatchPopup.module.scss";
import IMatchPopupStateMatchedUser from "../../interfaces/matchPopup/IMatchPopupStateMatchedUser";
import { Link } from "react-router-dom";
import { useSpring, animated } from "@react-spring/web";
import { useAppDispatch } from "../../hooks/reduxHooks";
import { toggleMatchPopupOff } from "../../store/matchPopup";

export const MatchPopup: React.FC<IMatchPopupStateMatchedUser> = (
  props: IMatchPopupStateMatchedUser
) => {
  const [message, setMessage] = useState<string>("");

  const dispatch = useAppDispatch();

  const [cardProps] = useSpring(() => ({
    from: {
      opacity: 0,
    },
    to: {
      opacity: 1,
    },
    config: {
      duration: 500,
    },
  }));

  return (
    <div className={styles.popupWrapper}>
      <animated.div
        style={{
          ...cardProps,
          background: `linear-gradient(rgba(0, 0, 0, 0.235), rgba(0, 0, 0, 0.4)), ${`url(data:image/png;base64,${props.firstProfilePicture}) center center / 100% 100%`} no-repeat`,
        }}
        className={styles.popupCard}
      >
        <p className={styles.matchMessage}>IT'S A MATCH</p>
        <div className={styles.sendMessageContainer}>
          <span>Be first to text {props.firstName}!</span>
          <form className={styles.sendMessageInputContainer}>
            <div className={styles.sendMessageInputWrapper}>
              <i className="fa-regular fa-comment-dots"></i>
              <input
                type="text"
                name="message"
                placeholder="Send message..."
                className={styles.sendMessageInput}
                value={message}
                onChange={(e) => setMessage(() => e.target.value)}
              />
            </div>
            <button className={styles.sendMessageBtn}>
              <i className="fa-solid fa-paper-plane"></i>
            </button>
          </form>
          <Link
            className={styles.backToHomeBtn}
            to={"/"}
            replace={true}
            onClick={() => dispatch(toggleMatchPopupOff())}
          >
            Back to home
          </Link>
        </div>
      </animated.div>
    </div>
  );
};
