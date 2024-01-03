import React, { useState } from "react";

export function useForm<T>(initialFormValues: T) {
  let [formValues, setFormValues] = useState(initialFormValues);

  const onFormTextAreaChange = (e: React.ChangeEvent<HTMLTextAreaElement>) => {
    const eventTarget = e.currentTarget as HTMLTextAreaElement;

    setFormValues((state) => ({
      ...state,
      [eventTarget.name]: eventTarget.value,
    }));
  };

  const onFormChange = (e: React.FormEvent<HTMLInputElement>) => {
    const eventTarget = e.currentTarget as HTMLInputElement;

    setFormValues((state) => ({
      ...state,
      [eventTarget.name]: eventTarget.value,
    }));
  };

  const onFormChangeImage = (e: React.FormEvent<HTMLInputElement>) => {
    const eventTarget = e.currentTarget as HTMLInputElement;

    setFormValues((state) => ({
      ...state,
      [eventTarget.name]: eventTarget.files?.item(0),
    }));
  };

  const setDefaultValues = (values: T) => {
    setFormValues(values);
  };

  return {
    formValues,
    onFormChange,
    setDefaultValues,
    onFormChangeImage,
    onFormTextAreaChange,
  };
}
