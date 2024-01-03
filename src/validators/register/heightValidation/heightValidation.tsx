export const heightValidation = (height: string | number): string => {
  if (height === "") {
    return "Height can't be empty";
  }

  if (typeof height === "string") {
    return Number.parseFloat(height.toString()) <= 0
      ? "Height must be more than zero"
      : "";
  }

  return height <= 0 ? "Height must be more than zero" : "";
};
