import { BASE_URL } from "../../constants/constants";

export const getUserSuggestedMatches = async (token: string) => {
  const response = await fetch(`${BASE_URL}/match/matches`, {
    headers: {
      "content-type": "application/json",
      authorization: `Bearer ${token}`,
    },
    method: "GET",
  });

  const responseJson = response.json();

  return responseJson;
};
