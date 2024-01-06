import { BASE_URL } from "../../constants/constants";
import IResponse from "../../interfaces/response/IResponse";

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

  const responseJson: IResponse = await response.json();

  return responseJson;
};
