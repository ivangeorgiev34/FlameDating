export function formErrorsValidation<T, U>(
  formValues: T,
  formErrors: U,
  nullablePropertyNames?: string[]
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
    if (typeof formValues[key] === "string") {
      if (
        (formValues as Record<string, any>)[key] === "" &&
        nullablePropertyNames?.some((propName) => propName === key) === false
      ) {
        return true;
      }
    } else if (typeof formValues[key] === "number") {
      if (
        (formValues as Record<string, any>)[key] === 0 &&
        nullablePropertyNames?.some((propName) => propName === key) === false
      ) {
        return true;
      }
    }
  }

  return false;
}
