import React, { FormEvent, FormEventHandler, useState } from "react";
import styles from "../Login/Login.module.scss";
import { Link, useNavigate } from "react-router-dom";
import { useForm } from "../../hooks/useForm/useForm";
import ILoginForm from "../../interfaces/login/ILoginForm";
import { useError } from "../../hooks/useError/useError";
import ILoginFormErrors from "../../interfaces/login/ILoginFormErrors";
import { emailValidation } from "../../validators/login/emailValidation/emailValidation";
import { passwordValidation } from "../../validators/login/passwordValidation/passwordValidation";
import { formErrorsValidation } from "../../validators/formErrorsValidation/formErrorsValidation";
import { userLogin } from "../../services/authenticationService/authenticationService";
import { useAppDispatch } from "../../hooks/reduxHooks";
import { toggleLoaderOff, toggleLoaderOn } from "../../store/loader";
import { login } from "../../store/auth";
import { error } from "console";
import { addInterests } from "../../store/interests";
import { getUsersInterest } from "../../services/interestService/interestService";

export const Login: React.FC = () => {
  const dispatch = useAppDispatch();
  const navigate = useNavigate();

  const [errors, setErrors] = useState<string[]>([]);

  const { formValues, onFormChange } = useForm<ILoginForm>({
    email: "",
    password: "",
  });

  const { formErrors, onFormErrorChange } = useError<ILoginFormErrors>({
    email: "",
    password: "",
  });

  const onLoginFormSubmit: FormEventHandler<HTMLFormElement> = async (
    e: FormEvent<HTMLFormElement>
  ) => {
    dispatch(toggleLoaderOn());

    e.preventDefault();

    setErrors([]);

    try {
      const loginResponse = await userLogin(
        formValues.email,
        formValues.password
      );

      if (loginResponse.status === "Error") {
        setErrors((errors) => [...errors, loginResponse.message]);
      } else if (loginResponse.status === "Success") {
        dispatch(
          login({
            id: loginResponse.content.user.id,
            firstName: loginResponse.content.user.firstName,
            middleName: loginResponse.content.user.middleName,
            lastName: loginResponse.content.user.lastName,
            age: loginResponse.content.user.age,
            email: loginResponse.content.user.email,
            username: loginResponse.content.user.username,
            gender: loginResponse.content.user.gender,
            biography: loginResponse.content.user.biography,
            school: loginResponse.content.user.school,
            job: loginResponse.content.user.job,
            height: loginResponse.content.user.height,
            firstProfilePicture: loginResponse.content.user.firstProfilePicture,
            secondProfilePicture:
              loginResponse.content.user.secondProfilePicture,
            thirdProfilePicture: loginResponse.content.user.thirdProfilePicture,
            fourthProfilePicture:
              loginResponse.content.user.fourthProfilePicture,
            fifthProfilePicture: loginResponse.content.user.fifthProfilePicture,
            token: loginResponse.content.token,
            expires: loginResponse.content.expires,
          })
        );

        const getUsersInterestResponse = await getUsersInterest(
          loginResponse.content.user.id,
          loginResponse.content.token
        );

        if (getUsersInterestResponse.status === "Error") {
          setErrors((errors) => [...errors, getUsersInterestResponse.message]);
        } else if (getUsersInterestResponse.status === "Success") {
          dispatch(addInterests(getUsersInterestResponse.content.interests));
        }

        navigate("/");
      }
    } catch (error: any) {
      setErrors((errors) => [...errors, error]);
    } finally {
      dispatch(toggleLoaderOff());
    }
  };

  return (
    <div className={styles.loginCardWrapper}>
      <form onSubmit={onLoginFormSubmit} className={styles.loginCard}>
        <h2>Login</h2>
        <hr />
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
        <div className={styles.passwordContainer}>
          <label htmlFor="password">Password:</label>
          <div className={styles.passwordInputContainer}>
            <i className="fa-solid fa-lock"></i>
            <input
              type="password"
              name="password"
              placeholder="Password..."
              value={formValues.password}
              onChange={(e) => onFormChange(e)}
              onBlur={(e) =>
                onFormErrorChange(e, passwordValidation(formValues.password))
              }
            />
          </div>
          <span className={styles.error}>{formErrors.password}</span>
        </div>
        <ul className={styles.errorsContainer}>
          {errors.map((errorMessage, index) => {
            return (
              <li key={index} className={styles.error}>
                {errorMessage}
              </li>
            );
          })}
        </ul>
        <span className={styles.registerLink}>
          Don't have an account?
          <Link to={"/register"}>Click here to register!</Link>
        </span>
        <button
          className={styles.loginBtn}
          disabled={formErrorsValidation<ILoginForm, ILoginFormErrors>(
            formValues,
            formErrors
          )}
        >
          Log in
        </button>
      </form>
    </div>
  );
};
