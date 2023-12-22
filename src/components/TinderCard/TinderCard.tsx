import React, { createContext, useEffect, useState } from "react";
import styles from "./TinderCard.module.scss";
import ITinderCardProps from "../../interfaces/tinderCard/ITinderCardProps";
import { url } from "inspector";
import { Link } from "react-router-dom";
import { TinderCardInformation } from "../TinderCardInformation/TinderCardInformation";
import { useAppDispatch } from "../../hooks/reduxHooks";
import { useSpring, animated } from "@react-spring/web";

export const TinderCardContext = createContext<{
  setIsInformationChecked: React.Dispatch<React.SetStateAction<boolean>>;
  isInformationChecked: boolean;
} | null>(null);

export const TinderCard: React.FC<ITinderCardProps> = (
  props: ITinderCardProps
) => {
  const notNullprofilePicturesCount = (): number => {
    let profilePicturesPropertyNames = [
      "firstProfilePicture",
      "secondProfilePicture",
      "thirdProfilePicture",
      "fourthProfilePicture",
      "fifthProfilePicture",
    ];

    let notNullprofilePicturesCount = Object.values(props).filter(
      (value, index) =>
        profilePicturesPropertyNames.includes(Object.keys(props)[index]) &&
        value !== null
    ).length;

    return notNullprofilePicturesCount;
  };

  const generateSliders = () => {
    let sliderElements: JSX.Element[] = [];

    let values = Object.values(props);

    for (let i = values.length - 1; i > values.length - 6; i--) {
      if (values[i] !== null) {
        const slider = (
          <li
            key={i}
            className={`${
              currentProfilePictureNumber === i - values.length + 6
                ? styles.activeSlider
                : styles.inactiveSlider
            }`}
          ></li>
        );

        sliderElements.push(slider);
      }
    }

    return sliderElements;
  };

  const onLikeBtnClick = (event: React.MouseEvent<HTMLElement>) => {
    event.preventDefault();

    api.start(() => {
      return {
        x: "220%",
        y: "100%",
        rotate: 25,
      };
    });
  };

  const onDislikeBtnClick = (event: React.MouseEvent<HTMLElement>) => {
    event.preventDefault();

    api.start(() => {
      return {
        x: "-220%",
        y: "100%",
        rotate: -25,
      };
    });
  };

  const [springProps, api] = useSpring(() => ({
    from: {
      x: "-50%",
      y: "-50%",
      rotate: 0,
    },
    config: {
      duration: 500,
    },
  }));

  const [isInformationChecked, setIsInformationChecked] =
    useState<boolean>(false);
  const [currentProfilePictureNumber, setCurrentProfilePictureNumber] =
    useState<number>(1);
  const [currentProfilePicture, setCurrentProfilePicture] = useState<string>(
    props.firstProfilePicture
  );
  const [totalProfilePicturesNumber, setTotalProfilePicturesNumber] =
    useState<number>(notNullprofilePicturesCount());

  useEffect(() => {
    switch (currentProfilePictureNumber) {
      case 1:
        setCurrentProfilePicture(props.firstProfilePicture);
        break;
      case 2:
        setCurrentProfilePicture(
          props.secondProfilePicture === null
            ? "./unknown-image.png"
            : props.secondProfilePicture
        );
        break;
      case 3:
        setCurrentProfilePicture(
          props.thirdProfilePicture === null
            ? "./unknown-image.png"
            : props.thirdProfilePicture
        );
        break;
      case 4:
        setCurrentProfilePicture(
          props.fourthProfilePicture === null
            ? "./unknown-image.png"
            : props.fourthProfilePicture
        );
        break;
      case 5:
        setCurrentProfilePicture(
          props.fifthProfilePicture === null
            ? "./unknown-image.png"
            : props.fifthProfilePicture
        );
        break;
    }
  }, [currentProfilePictureNumber]);

  return (
    <animated.div className={styles.matchWrapper} style={springProps}>
      <div
        style={{
          background: `linear-gradient(rgba(0, 0, 0, 0.235), rgba(0, 0, 0, 0.4)), ${
            currentProfilePicture === "./unknown-image.png"
              ? `url(${currentProfilePicture}) center center / 100% 100%`
              : `url(data:image/png;base64,${currentProfilePicture}) center center / 100% 100%`
          } no-repeat`,
        }}
        className={styles.card}
      >
        <ul className={styles.pictureSliders}>{generateSliders()}</ul>
        <button
          className={styles.previousPictureBtn}
          onClick={() => setCurrentProfilePictureNumber((state) => state - 1)}
          disabled={currentProfilePictureNumber === 1}
        >
          <i className="fa-solid fa-less-than fa-xl"></i>
        </button>
        <button
          className={styles.nextPictureBtn}
          onClick={() => setCurrentProfilePictureNumber((state) => state + 1)}
          disabled={
            currentProfilePictureNumber === 5 ||
            currentProfilePictureNumber === totalProfilePicturesNumber
          }
        >
          <i className="fa-solid fa-greater-than fa-xl"></i>
        </button>
        {isInformationChecked === false ? (
          <div className={styles.matchInformationWrapper}>
            <div className={styles.firstNameAndDistanceContainer}>
              <h2 className={styles.firstName}>
                {props.firstName} {props.age}
              </h2>
              <div className={styles.distanceFromUser}>
                <i className="fa-solid fa-location-dot fa-2xs"></i>
                <p>{props.distanceFromUser} km away</p>
              </div>
            </div>
            <button
              className={styles.openInformationBtn}
              onClick={() => setIsInformationChecked((state) => !state)}
            >
              <i className="fa-solid fa-circle-info fa-xl"></i>
            </button>
          </div>
        ) : (
          <></>
        )}
        {isInformationChecked === false ? (
          <div className={styles.likeBtnsContainer}>
            <button className={styles.dislikeBtn} onClick={onDislikeBtnClick}>
              <i className="fa-solid fa-x fa-2xl"></i>
            </button>
            <button className={styles.likeBtn} onClick={onLikeBtnClick}>
              <i className="fa-solid fa-heart fa-2xl"></i>
            </button>
          </div>
        ) : (
          <button
            className={styles.closeInformationBtn}
            onClick={() => setIsInformationChecked!((state) => !state)}
          >
            <i className="fa-solid fa-x fa-2xl"></i>
          </button>
        )}
      </div>
      {isInformationChecked === true ? (
        <TinderCardContext.Provider
          value={{ setIsInformationChecked, isInformationChecked }}
        >
          <TinderCardInformation
            {...props}
            {...{ onLikeBtnClick, onDislikeBtnClick }}
          />
        </TinderCardContext.Provider>
      ) : (
        <></>
      )}
    </animated.div>
  );
};
