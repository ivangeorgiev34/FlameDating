import React, { useContext, useEffect, useState } from "react";
import styles from "./TinderCardInformation.module.scss";
import ITinderCardProps from "../../interfaces/tinderCard/ITinderCardProps";
import { TinderCardContext } from "../TinderCard/TinderCard";
import { useAppDispatch, useAppSelector } from "../../hooks/reduxHooks";
import { getUsersInterest } from "../../services/interestService/interestService";
import { toggleLoaderOff, toggleLoaderOn } from "../../store/loader";
import { useNavigate } from "react-router-dom";
import IInterest from "../../interfaces/interests/IInterest/IInterest";

interface ITinderCardInformationProps extends ITinderCardProps {
  onLikeBtnClick: (event: React.MouseEvent<HTMLElement>) => void;
  onDislikeBtnClick: (event: React.MouseEvent<HTMLElement>) => void;
}

export const TinderCardInformation: React.FC<ITinderCardInformationProps> = (
  props
) => {
  const { isInformationChecked } = useContext(TinderCardContext) ?? {};

  const dispatch = useAppDispatch();

  const navigate = useNavigate();

  const { interests } = useAppSelector((selector) => selector.interests);
  const { token } = useAppSelector((selector) => selector.auth);

  const [tinderCardInterests, setTinderCardInterests] = useState<IInterest[]>(
    []
  );

  useEffect(() => {
    dispatch(toggleLoaderOn());

    setTinderCardInterests([]);

    getUsersInterest(props.id, token!)
      .then((response) => {
        if (response.status === "Error") {
          navigate("/not-found");
        } else if (response.status === "Success") {
          setTinderCardInterests((state) => [
            ...state,
            ...response.content.interests,
          ]);
        }
      })
      .catch()
      .finally(() => {
        dispatch(toggleLoaderOff());
      });
  }, []);

  const getInterests = () => {
    const commonInterestElements: JSX.Element[] = [];
    const uncommonInterestElements: JSX.Element[] = [];

    tinderCardInterests.forEach((interest) => {
      const hasCommonInterest = interests?.some((i) => i.id === interest.id);

      if (hasCommonInterest === true) {
        commonInterestElements.push(
          <span className={styles.commonInterest} key={interest.id}>
            {interest.name}
          </span>
        );

        return;
      }
      uncommonInterestElements.push(
        <span className={styles.uncommonInterest} key={interest.id}>
          {interest.name}
        </span>
      );
    });

    return [...commonInterestElements, ...uncommonInterestElements];
  };

  return (
    <div className={styles.matchInformationContainer}>
      <div className={styles.matchInformationWrapper}>
        <div className={styles.generalInformationContainer}>
          <h2 className={styles.firstName}>
            {props.firstName} {props.age}
          </h2>
          <p className={styles.matchInformation}>
            <i className="fa-solid fa-graduation-cap fa-2xs"></i>
            {props.school}
          </p>
          <p className={styles.matchInformation}>
            <i className="fa-solid fa-suitcase fa-2xs"></i>
            {props.job}
          </p>
          <p className={styles.matchInformation}>
            <i className="fa-solid fa-location-dot fa-2xs"></i>
            {props.distanceFromUser} km away
          </p>
        </div>
        <hr />
        <div className={styles.generalInformationContainer}>
          <h2>Height</h2>
          <p className={styles.matchInformation}>
            <i className="fa-solid fa-ruler-vertical fa-2xs"></i>
            {props.height} cm
          </p>
        </div>
        <hr />
        <div className={styles.generalInformationContainer}>
          <h2>Bio</h2>
          <p className={styles.matchInformation}>{props.biography}</p>
        </div>
        <hr />
        <div className={styles.generalInformationContainer}>
          <h2>Interests</h2>
          <ul className={styles.interestsContainer}>{getInterests()}</ul>
        </div>
      </div>
      {isInformationChecked === true ? (
        <>
          <button
            className={styles.dislikeBtn}
            onClick={props.onDislikeBtnClick}
          >
            <i className="fa-solid fa-x fa-2xl"></i>
          </button>
          <button className={styles.likeBtn} onClick={props.onLikeBtnClick}>
            <i className="fa-solid fa-heart fa-2xl"></i>
          </button>
        </>
      ) : (
        <></>
      )}
    </div>
  );
};
