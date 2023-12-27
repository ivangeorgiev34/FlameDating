import React, { useEffect, useState } from "react";
import styles from "./MatchPopup.module.scss";
import IMatchPopupStateMatchedUser from "../../interfaces/matchPopup/IMatchPopupStateMatchedUser";
import { Link, useNavigate } from "react-router-dom";
import { useSpring, animated } from "@react-spring/web";
import { useAppDispatch, useAppSelector } from "../../hooks/reduxHooks";
import { toggleMatchPopupOff } from "../../store/matchPopup";
import { messageValidation } from "../../validators/matchPopup/messageValidation";
import { useError } from "../../hooks/useError/useError";
import IMatchPopupFormErrors from "../../interfaces/matchPopup/IMatchPopupFormErrors";
import { formErrorsValidation } from "../../validators/formErrorsValidation/formErrorsValidation";
import { useForm } from "../../hooks/useForm/useForm";
import IMatchPopupForm from "../../interfaces/matchPopup/IMatchPopupForm";
import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";
import { BASE_URL } from "../../constants/constants";
import { getChatId } from "../../services/chatService/chatService";
import { toggleLoaderOff, toggleLoaderOn } from "../../store/loader";

export const MatchPopup: React.FC<IMatchPopupStateMatchedUser> = (
  props: IMatchPopupStateMatchedUser
) => {
  const { token } = useAppSelector((selector) => selector.auth);

  const [chatId, setChatId] = useState<string>("");

  const [connection] = useState<HubConnection>(
    new HubConnectionBuilder()
      .withUrl(`https://localhost:7183/chatHub`, {
        accessTokenFactory: () => (token !== null ? token : ""),
      })
      .build()
  );

  const { formValues, onFormChange } = useForm<IMatchPopupForm>({
    message: "",
  });

  const { formErrors, onFormErrorChange } = useError<IMatchPopupFormErrors>({
    message: "",
  });
  const dispatch = useAppDispatch();

  const navigate = useNavigate();

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

  const onSendMessageFormSubmit: React.FormEventHandler<
    HTMLFormElement
  > = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    await connection.invoke(
      "SendMessageAsync",
      formValues.message,
      chatId,
      props.id
    );
  };

  useEffect(() => {
    dispatch(toggleLoaderOn());

    getChatId(token!, props.id)
      .then((response) => {
        if (response.status === "Error") {
          if (response.message === "Not authorized") {
            navigate("/unauthorized");
          } else if (response.message === "User not found") {
            navigate("/not-found");
          }
        } else if (response.status === "Success") {
          setChatId(response.content?.id);
        }
      })
      .finally(() => {
        dispatch(toggleLoaderOff());
      });

    connection.start().catch(() => {
      navigate("/internal-server-error");
    });

    return () => {
      connection.stop().catch(() => {
        navigate("/internal-server-error");
      });
    };
  }, [connection, chatId]);

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
          <form
            className={styles.sendMessageInputContainer}
            onSubmit={(e) => onSendMessageFormSubmit(e)}
          >
            <div className={styles.sendMessageInputWrapper}>
              <i className="fa-regular fa-comment-dots"></i>
              <input
                type="text"
                name="message"
                placeholder="Send message..."
                className={styles.sendMessageInput}
                value={formValues.message}
                onChange={(e) => onFormChange(e)}
                onBlur={(e) =>
                  onFormErrorChange(e, messageValidation(formValues.message))
                }
              />
            </div>
            <button
              className={styles.sendMessageBtn}
              disabled={formErrorsValidation<
                IMatchPopupForm,
                IMatchPopupFormErrors
              >(formValues, formErrors)}
            >
              <i className="fa-solid fa-paper-plane"></i>
            </button>
          </form>
          <span className={styles.error}>{formErrors.message}</span>
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
