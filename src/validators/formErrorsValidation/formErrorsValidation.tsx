export function formErrorsValidation<T, U>(
  formValues: T,
  formErrors: U
): boolean {
  for (let key in formErrors) {
    if (
      formErrors!.hasOwnProperty(key) &&
      (formErrors as Record<string, any>)[key] !== ""
    ) {
      return true;
    }
  }

  for (let key in formValues) {
    if (
      formValues!.hasOwnProperty(key) &&
      (formValues as Record<string, any>)[key] === ""
    ) {
      return true;
    }
  }

  return false;
}
