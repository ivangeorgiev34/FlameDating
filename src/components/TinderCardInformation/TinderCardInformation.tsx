import React, { useContext, useEffect, useState } from "react";
import styles from "./TinderCardInformation.module.scss";
import ITinderCardProps from "../../interfaces/tinderCard/ITinderCardProps";
import { TinderCardContext } from "../TinderCard/TinderCard";
import { useAppSelector } from "../../hooks/reduxHooks";

export const TinderCardInformation: React.FC<ITinderCardProps> = (props) => {
  const { setIsInformationChecked, isInformationChecked } =
    useContext(TinderCardContext) ?? {};

  const { interests } = useAppSelector((selector) => selector.interests);

  return (
    <div className={styles.matchInformationContainer}>
      <div className={styles.matchInformationWrapper}>
        <div className={styles.firstNameAndDistanceContainer}>
          <h2 className={styles.firstName}>
            {props.firstName} {props.age}
          </h2>
          <p className={styles.distanceFromUser}>
            <i className="fa-solid fa-location-dot fa-2xs"></i>
            {props.distanceFromUser} km away
          </p>
        </div>
      </div>
      {isInformationChecked === true ? (
        <div className={styles.likeBtnsContainer}>
          <button className={styles.dislikeBtn}>
            <i className="fa-solid fa-x fa-2xl"></i>
          </button>
          <button className={styles.likeBtn}>
            <i className="fa-solid fa-heart fa-2xl"></i>
          </button>
        </div>
      ) : (
        <></>
      )}
    </div>
  );
};
