import { BASE_URL } from "../../constants/constants";

export const userLogin = async (email: string, password: string) => {
  const response = await fetch(`${BASE_URL}/account/login`, {
    headers: {
      "content-type": "application/json",
    },
    method: "POST",
    body: JSON.stringify({
      email: email,
      password: password,
    }),
  });

  const responseJson = response.json();

  return responseJson;
};

export const userRegister = async (formData: FormData) => {
  const response = await fetch(`${BASE_URL}/account/register`, {
    method: "POST",
    body: formData,
  });

  const responseJson = response.json();

  return responseJson;
};
