export const emailValidation = (email: string): string => {
  if (email === "") {
    return "Email can't be empty";
  } else if (
    new RegExp("^[A-Za-z0-9_.]+@[A-Za-z]+.[A-Za-z]{2,3}$").test(email) === false
  ) {
    return "Invalid email";
  }

  return "";
};
