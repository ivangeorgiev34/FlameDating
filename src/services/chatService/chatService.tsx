import { BASE_URL } from "../../constants/constants";
import IResponse from "../../interfaces/response/IResponse";

export const getChatId = async (
  token: string,
  recieverId: string
): Promise<IResponse> => {
  try {
    const response = await fetch(
      `${BASE_URL}/chat/chats/reciever/${recieverId}`,
      {
        headers: {
          "content-type": "application/json",
          Authorization: `Bearer ${token}`,
        },
        method: "GET",
      }
    );

    const responseJson: IResponse = await response.json();

    return responseJson;
  } catch (error) {
    return { status: "Error", message: "Unexpected error" };
  }
};
