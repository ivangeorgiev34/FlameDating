import React from "react";
import styles from "./Register.module.scss";
import { useForm } from "../../hooks/useForm/useForm";
import IRegisterForm from "../../interfaces/register/IRegisterForm";
import { useError } from "../../hooks/useError/useError";
import IRegisterFormErrors from "../../interfaces/register/IRegisterFormErrors";
import { firstNameValidation } from "../../validators/register/firstNameValidation";

export const Register: React.FC = () => {
  const { formValues, onFormChange, onFormChangeImage } =
    useForm<IRegisterForm>({
      firstName: "",
      middleName: "",
      lastName: "",
      age: 0,
      gender: "",
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
              type="firstName"
              name="passwfirstNameord"
              placeholder="First name..."
              value={formValues.firstName}
              onChange={(e) => onFormChange(e)}
              onBlur={(e) =>
                onFormErrorChange(e, firstNameValidation(formValues.firstName))
              }
            />
          </div>
          <span className={styles.error}>{formErrors.password}</span>
        </div>
      </div>
    </div>
  );
};
