export const maximumDistanceValidation = (
  maximumDistance: string | number
): string => {
  if (maximumDistance === "") {
    return "Maximum distance can't be empty";
  }

  if (typeof maximumDistance === "string") {
    const maximumDistanceNumber = Number.parseFloat(maximumDistance);

    return Number.isInteger(maximumDistanceNumber) === false
      ? "Maximum distance must be a whole number"
      : maximumDistanceNumber <= 0
      ? "Maximum distance must be more than zero"
      : maximumDistanceNumber < 2 || maximumDistanceNumber > 150
      ? "Maximum distance must be between 2 km and 150 km"
      : "";
  }

  return Number.isInteger(maximumDistance) === false
    ? "Maximum distance must be a whole number"
    : maximumDistance <= 0
    ? "Maximum distance must be more than zero"
    : maximumDistance < 2 || maximumDistance > 150
    ? "Maximum distance must be between 2 km and 150 km"
    : "";
};
