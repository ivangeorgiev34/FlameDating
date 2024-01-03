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
      preferedGender: "",
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
      </div>
    </div>
  );
};
