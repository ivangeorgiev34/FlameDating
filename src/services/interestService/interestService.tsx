import { promises } from "dns";
import { BASE_URL } from "../../constants/constants";

export const getUsersInterest = async (id: string, token: string) => {
  const response = await fetch(`${BASE_URL}/interest/interests/${id}`, {
    method: "GET",
    headers: {
      "content-type": "application/json",
      authorization: `Bearer ${token}`,
    },
  });

  const responseJson = await response.json();

  return responseJson;
};
