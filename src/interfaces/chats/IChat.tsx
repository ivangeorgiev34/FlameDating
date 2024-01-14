import IUser from "../user/IUser";

export default interface IChat {
  id: string;
  currentUser: IUser;
  recipientUser: IUser;
}
