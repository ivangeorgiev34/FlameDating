export const ageValidation = (age: string | number): string => {
  if (age === "") {
    return "Age can't be empty";
  }

  if (typeof age === "string") {
    return Number.isInteger(Number.parseFloat(age)) === false
      ? "Age must be a whole number"
      : Number.parseFloat(age) <= 0
      ? "Age must be more than zero"
      : "";
  }

  return Number.isInteger(age) === false
    ? "Age must be a whole number"
    : age <= 0
    ? "Age must be more than zero"
    : "";
};
