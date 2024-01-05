import React from "react";
import styles from "./Register.module.scss";
import { useForm } from "../../hooks/useForm/useForm";
import IRegisterForm from "../../interfaces/register/IRegisterForm";
import { useError } from "../../hooks/useError/useError";
import IRegisterFormErrors from "../../interfaces/register/IRegisterFormErrors";
import { firstNameValidation } from "../../validators/register/firstNameValidation/firstNameValidation";
import { middleNameValidation } from "../../validators/register/middleNameValidation/middleNameValidation";
import { lastNameValidation } from "../../validators/register/lastNameValidation/lastNameValidation";
import { heightValidation } from "../../validators/register/heightValidation/heightValidation";
import { ageValidation } from "../../validators/register/ageValidation/ageValidation";
import { firstProfilePictureValidation } from "../../validators/register/firstProfilePictureValidation/firstProfilePictureValidation";
import { maximumDistanceValidation } from "../../validators/register/maximumDistanceValidation/maximumDistanceValidation";
import { emailValidation } from "../../validators/login/emailValidation/emailValidation";

export const Register: React.FC = () => {
  const { formValues, onFormChange, onFormChangeImage, onFormTextAreaChange } =
    useForm<IRegisterForm>({
      firstName: "",
      middleName: "",
      lastName: "",
      age: 0,
      gender: "Male",
      height: 0,
      school: "",
      job: "",
      biography: "",
      firstProfilePicture: null,
      secondProfilePicture: null,
      thirdProfilePicture: null,
      fourthProfilePicture: null,
      fifthProfilePicture: null,
      maximumDistance: 0,
      preferedGender: "Male",
      email: "",
      username: "",
      password: "",
      confirmPassword: "",
      locationLatitude: 0,
      locationLongitude: 0,
    });

  const { formErrors, onFormErrorChange } = useError<IRegisterFormErrors>({
    firstName: "",
    middleName: "",
    lastName: "",
    age: "",
    gender: "",
    height: "",
    school: "",
    job: "",
    biography: "",
    firstProfilePicture: "",
    secondProfilePicture: "",
    thirdProfilePicture: "",
    fourthProfilePicture: "",
    fifthProfilePicture: "",
    maximumDistance: "",
    preferedGender: "",
    email: "",
    username: "",
    password: "",
    confirmPassword: "",
    location: "",
  });

  const generateProfilePictureContainers = (): JSX.Element[] => {
    const profilePicturesKeys: { [key: string]: string } = {
      1: "firstProfilePicture",
      2: "secondProfilePicture",
      3: "thirdProfilePicture",
      4: "fourthProfilePicture",
      5: "fifthProfilePicture",
    };

    const profilePictureContainers: JSX.Element[] = [];

    let currentProfilePictureContainer;
    let currentProfilePictureValue;

    for (const key in profilePicturesKeys) {
      currentProfilePictureValue = profilePicturesKeys[key];

      currentProfilePictureContainer = (
        <div
          className={styles.profilePictureContainer}
          key={currentProfilePictureValue}
        >
          <label>{getProfilePicturePropertyName(Number.parseInt(key))}</label>
          <img
            className={styles.profilePicture}
            src={
              formValues[currentProfilePictureValue] === null
                ? "/unknown-image.png"
                : URL.createObjectURL(
                    formValues[currentProfilePictureValue] as File
                  )
            }
            alt={currentProfilePictureValue}
          />
          <input
            className={styles.profilePictureInput}
            type="file"
            accept="image/png, image/jpeg, image/jpg"
            name={currentProfilePictureValue}
            id={currentProfilePictureValue}
            onChange={(e) => {
              onFormChangeImage(e);
              onFormErrorChange(
                e,
                firstProfilePictureValidation(
                  e.target.files !== null ? e.target.files.item(0) : null
                )
              );
            }}
          />
          <label
            className={styles.uploadProfilePictureBtn}
            htmlFor={currentProfilePictureValue}
          >
            Upload
          </label>
        </div>
      );

      profilePictureContainers.push(currentProfilePictureContainer);
    }

    return profilePictureContainers;
  };

  const getProfilePicturePropertyName = (num: number) => {
    switch (num) {
      case 1:
        return "First profile picture:";
      case 2:
        return "Second profile picture:";
      case 3:
        return "Third profile picture:";
      case 4:
        return "Fourth profile picture:";
      case 5:
        return "Fifth profile picture:";
    }
  };

  return (
    <div className={styles.registerCardContainer}>
      <div className={styles.registerCard}>
        <h2>Register</h2>
        <div className={styles.firstNameContainer}>
          <label htmlFor="firstName">First name:</label>
          <div className={styles.firstNameInputContainer}>
            <i className="fa-solid fa-user"></i>
            <input
              type="text"
              name="firstName"
              placeholder="First name..."
              value={formValues.firstName}
              onChange={(e) => onFormChange(e)}
              onBlur={(e) =>
                onFormErrorChange(e, firstNameValidation(formValues.firstName))
              }
            />
          </div>
          <span className={styles.error}>{formErrors.firstName}</span>
        </div>
        <div className={styles.middleNameContainer}>
          <label htmlFor="middleName">Middle name:</label>
          <div className={styles.middleNameInputContainer}>
            <i className="fa-solid fa-user"></i>
            <input
              type="text"
              name="middleName"
              placeholder="Middle name..."
              value={formValues.middleName}
              onChange={(e) => onFormChange(e)}
              onBlur={(e) =>
                onFormErrorChange(
                  e,
                  middleNameValidation(formValues.middleName)
                )
              }
            />
          </div>
          <span className={styles.error}>{formErrors.middleName}</span>
        </div>
        <div className={styles.lastNameContainer}>
          <label htmlFor="lastName">Last name:</label>
          <div className={styles.lastNameInputContainer}>
            <i className="fa-solid fa-user"></i>
            <input
              type="text"
              name="lastName"
              placeholder="Last name..."
              value={formValues.lastName}
              onChange={(e) => onFormChange(e)}
              onBlur={(e) =>
                onFormErrorChange(e, lastNameValidation(formValues.lastName))
              }
            />
          </div>
          <span className={styles.error}>{formErrors.lastName}</span>
        </div>
        <div className={styles.genderContainer}>
          <div className={styles.genderOptionContainer}>
            <label htmlFor="male">Male:</label>
            <input
              type="radio"
              id="male"
              name="gender"
              value="Male"
              onChange={onFormChange}
              checked={formValues.gender === "Male"}
            />
          </div>
          <div className={styles.genderOptionContainer}>
            <label htmlFor="female">Female:</label>
            <input
              type="radio"
              id="female"
              name="gender"
              value="Female"
              onChange={onFormChange}
              checked={formValues.gender === "Female"}
            />
          </div>
        </div>
        <div className={styles.heightContainer}>
          <label htmlFor="height">Height:</label>
          <div className={styles.heightInputContainer}>
            <i className="fa-solid fa-ruler"></i>
            <input
              type="number"
              name="height"
              placeholder="Height..."
              value={formValues.height}
              onChange={(e) => onFormChange(e)}
              onBlur={(e) =>
                onFormErrorChange(e, heightValidation(formValues.height))
              }
            />
          </div>
          <span className={styles.error}>{formErrors.height}</span>
        </div>
        <div className={styles.ageContainer}>
          <label htmlFor="age">Age:</label>
          <div className={styles.ageInputContainer}>
            <i className="fa-solid fa-arrow-up-1-9"></i>
            <input
              type="number"
              name="age"
              placeholder="Age..."
              value={formValues.age}
              onChange={(e) => onFormChange(e)}
              onBlur={(e) =>
                onFormErrorChange(e, ageValidation(formValues.age))
              }
            />
          </div>
          <span className={styles.error}>{formErrors.age}</span>
        </div>
        <div className={styles.schoolContainer}>
          <label htmlFor="school">School:</label>
          <div className={styles.schoolInputContainer}>
            <i className="fa-solid fa-school"></i>
            <input
              type="text"
              name="school"
              placeholder="School..."
              value={formValues.school}
              onChange={(e) => onFormChange(e)}
            />
          </div>
        </div>
        <div className={styles.jobContainer}>
          <label htmlFor="job">Job:</label>
          <div className={styles.jobInputContainer}>
            <i className="fa-solid fa-suitcase"></i>
            <input
              type="text"
              name="job"
              placeholder="Job..."
              value={formValues.job}
              onChange={(e) => onFormChange(e)}
            />
          </div>
        </div>
        <div className={styles.biographyContainer}>
          <label htmlFor="biography">Biography:</label>
          <textarea
            name="biography"
            id="biography"
            rows={10}
            value={formValues.biography}
            onChange={(e) => onFormTextAreaChange(e)}
          />
        </div>
        <div className={styles.profilePicturesContainer}>
          {generateProfilePictureContainers()}
        </div>
        <hr />
        <h4>Select preferred maximum distance and gender:</h4>
        <div className={styles.maximumDistanceContainer}>
          <label htmlFor="maximumDistance">Maximum distance:</label>
          <div className={styles.maximumDistanceInputContainer}>
            <i className="fa-solid fa-map-location-dot"></i>
            <input
              type="number"
              name="maximumDistance"
              placeholder="Maximum distance..."
              value={formValues.maximumDistance}
              onChange={(e) => onFormChange(e)}
              onBlur={(e) =>
                onFormErrorChange(
                  e,
                  maximumDistanceValidation(formValues.maximumDistance)
                )
              }
            />
          </div>
          <span className={styles.error}>{formErrors.maximumDistance}</span>
        </div>
        <div className={styles.preferedGenderContainerWrapper}>
          <p>Preferred gender:</p>
          <div className={styles.preferedGenderContainer}>
            <div className={styles.preferedGenderOptionContainer}>
              <label htmlFor="male">Male:</label>
              <input
                type="radio"
                id="male"
                name="preferedGender"
                value="Male"
                onChange={(e) => onFormChange(e)}
                checked={formValues.preferedGender === "Male"}
              />
            </div>
            <div className={styles.preferedGenderOptionContainer}>
              <label htmlFor="female">Female:</label>
              <input
                type="radio"
                id="female"
                name="preferedGender"
                value="Female"
                onChange={(e) => onFormChange(e)}
                checked={formValues.preferedGender === "Female"}
              />
            </div>
          </div>
        </div>
        <hr />
        <h4>Type out your desired user credentials:</h4>
        <div className={styles.usernameContainer}>
          <label htmlFor="username">Username:</label>
          <div className={styles.usernameInputContainer}>
            <i className="fa-solid fa-user"></i>
            <input
              type="text"
              name="username"
              placeholder="Username..."
              value={formValues.username}
              onChange={(e) => onFormChange(e)}
            />
          </div>
        </div>
        <div className={styles.emailContainer}>
          <label htmlFor="email">Email:</label>
          <div className={styles.emailInputContainer}>
            <i className="fa-solid fa-envelope"></i>
            <input
              type="email"
              name="email"
              placeholder="Email..."
              value={formValues.email}
              onChange={(e) => onFormChange(e)}
              onBlur={(e) =>
                onFormErrorChange(e, emailValidation(formValues.email))
              }
            />
          </div>
          <span className={styles.error}>{formErrors.email}</span>
        </div>
      </div>
    </div>
  );
};
