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
      const response = await userLogin(formValues.email, formValues.password);

      if (response.status === "Error") {
        setErrors((errors) => [...errors, response.message]);
      } else if (response.status === "Success") {
        dispatch(
          login({
            id: response.content.user.id,
            firstName: response.content.user.firstName,
            middleName: response.content.user.middleName,
            lastName: response.content.user.lastName,
            age: response.content.user.age,
            email: response.content.user.email,
            username: response.content.user.username,
            gender: response.content.user.gender,
            biography: response.content.user.biography,
            school: response.content.user.school,
            job: response.content.user.job,
            height: response.content.user.height,
            firstProfilePicture: response.content.user.firstProfilePicture,
            secondProfilePicture: response.content.user.secondProfilePicture,
            thirdProfilePicture: response.content.user.thirdProfilePicture,
            fourthProfilePicture: response.content.user.fourthProfilePicture,
            fifthProfilePicture: response.content.user.fifthProfilePicture,
            token: response.content.token,
            expires: response.content.expires,
          })
        );

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
