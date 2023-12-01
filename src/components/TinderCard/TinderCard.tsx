import React, { useEffect, useState } from "react";
import styles from "./TinderCard.module.scss";
import ITinderCardProps from "../../interfaces/tinderCard/ITinderCardProps";
import { url } from "inspector";
import { Link } from "react-router-dom";

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

  const [isInformationChecked, setIsInformationChecked] =
    useState<boolean>(false);
  const [currentProfilePictureNumber, setCurrentProfilePictureNumber] =
    useState<number>(1);
  const [currentProfilePicture, setCurrentProfilePicture] = useState<string>(
    props.firstProfilePicture
  );
  const [totalProfilePicturesNumber, setTotalProfilePicturesNumber] =
    useState<number>(notNullprofilePicturesCount());

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
        onClick={() => setCurrentProfilePictureNumber((state) => state - 1)}
        disabled={currentProfilePictureNumber === 1}
      >
        <i className="fa-solid fa-less-than fa-lg"></i>
      </button>
      <button
        onClick={() => setCurrentProfilePictureNumber((state) => state + 1)}
        disabled={
          currentProfilePictureNumber === 5 ||
          currentProfilePictureNumber === totalProfilePicturesNumber
        }
      >
        <i className="fa-solid fa-greater-than fa-lg"></i>
      </button>
      <div>
        <div>
          <h1 className={styles.firstName}>
            {props.firstName} {props.age}
          </h1>
          <p>{props.distanceFromUser} km away</p>
        </div>
        <button>
          <i className="fa-solid fa-circle-info"></i>
        </button>
      </div>
    </div>
  );
};
