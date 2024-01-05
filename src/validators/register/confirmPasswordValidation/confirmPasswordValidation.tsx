export const confirmPasswordValidation = (
  password: string,
  confirmPassword: string
): string => {
  return password !== confirmPassword ? "Passwords don't match" : "";
};
