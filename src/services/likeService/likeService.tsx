import { BASE_URL } from "../../constants/constants";
import IResponse from "../../interfaces/response/IResponse";

export const likeUser = async (
  token: string,
  likedUserId: string
): Promise<IResponse> => {
  try {
    const response = await fetch(`${BASE_URL}/like/like/${likedUserId}`, {
      headers: {
        "content-type": "application/json",
        Authorization: `Bearer ${token}`,
      },
      method: "POST",
    });

    const responseJson: IResponse = await response.json();

    return responseJson;
  } catch (error) {
    return { status: "Error", message: "Unexpected error" };
  }
};

export const dislikeUser = async (
  token: string,
  dislikedUserId: string
): Promise<IResponse> => {
  try {
    const response = await fetch(`${BASE_URL}/like/dislike/${dislikedUserId}`, {
      headers: {
        "content-type": "application/json",
        Authorization: `Bearer ${token}`,
      },
      method: "POST",
    });

    const responseJson: IResponse = await response.json();

    return responseJson;
  } catch (error) {
    return { status: "Error", message: "Unexpected error" };
  }
};
