import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import IMatchPopupState from "../interfaces/matchPopup/IMatchPopupState";
import produce from "immer";
import IMatchPopupStateMatchedUser from "../interfaces/matchPopup/IMatchPopupStateMatchedUser";

const initialState: IMatchPopupState = {
  isMatchPopupActive: false,
  matchedUser: null,
};

const matchPopupSlice = createSlice({
  name: "matchPopup",
  initialState: initialState,
  reducers: {
    toggleMatchPopupOn: (
      state,
      action: PayloadAction<IMatchPopupStateMatchedUser>
    ) => {
      return produce(state, (draftState) => {
        draftState.isMatchPopupActive = true;
        draftState.matchedUser = action.payload;
      });
    },
    toggleMatchPopupOff: (state) => {
      return produce(state, (draftState) => {
        draftState.isMatchPopupActive = false;
        draftState.matchedUser = null;
      });
    },
  },
});

export const { toggleMatchPopupOn, toggleMatchPopupOff } =
  matchPopupSlice.actions;

export default matchPopupSlice.reducer;
