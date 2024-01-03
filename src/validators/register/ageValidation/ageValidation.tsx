export const ageValidation = (age: string | number): string => {
  if (age === "") {
    return "Age can't be empty";
  }

  if (typeof age === "string") {
    return Number.isInteger(Number.parseFloat(age)) === false
      ? "Age must be a whole number"
      : Number.parseInt(age) <= 0
      ? "Age must be more than zero"
      : Number.parseInt(age) < 18 || Number.parseInt(age) > 100
      ? "Age must be between 18 and 100"
      : "";
  }

  return Number.isInteger(age) === false
    ? "Age must be a whole number"
    : age <= 0
    ? "Age must be more than zero"
    : age < 18 || age > 100
    ? "Age must be between 18 and 100"
    : "";
};
