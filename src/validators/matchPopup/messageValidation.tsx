export const messageValidation = (message: string): string => {
  return message === "" ? "Cannot send an empty message!" : "";
};
