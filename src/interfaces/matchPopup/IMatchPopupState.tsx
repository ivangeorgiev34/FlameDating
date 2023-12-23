import IMatchPopupStateMatchedUser from "./IMatchPopupStateMatchedUser";

export default interface IMatchPopupState {
  isMatchPopupActive: boolean;
  matchedUser: IMatchPopupStateMatchedUser | null;
}
