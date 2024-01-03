export const heightValidation = (height: string | number): string => {
  if (height === "") {
    return "Height can't be empty";
  }

  if (typeof height === "string") {
    return Number.parseFloat(height) <= 0
      ? "Height must be more than zero"
      : Number.parseFloat(height) < 1.2 || Number.parseFloat(height) > 2.5
      ? "Height must be in range between 1.20 cm and 2.50 cm"
      : "";
  }

  return height <= 0
    ? "Height must be more than zero"
    : height < 1.2 || height > 2.5
    ? "Height must be in range between 1.20 cm and 2.50 cm"
    : "";
};
