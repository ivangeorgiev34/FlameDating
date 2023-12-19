import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import IInterestsState from "../interfaces/interests/IInterestsState/IInterestsState";
import IInterest from "../interfaces/interests/IInterest/IInterest";
import produce from "immer";

export const initialState: IInterestsState =
  localStorage.getItem("interests") === null
    ? {
        interests: [],
      }
    : JSON.parse(localStorage.getItem("interests")!);

const interestsSlice = createSlice({
  name: "interests",
  initialState: initialState,
  reducers: {
    addInterests: (state, action: PayloadAction<IInterest[]>) => {
      localStorage.setItem("interests", JSON.stringify(action.payload));

      return produce(state, (draftState) => {
        draftState.interests = action.payload;
      });
    },
    removeInterests: (state) => {
      localStorage.removeItem("interests");

      return produce(state, (draftState) => {
        draftState.interests = [];
      });
    },
  },
});

export const { addInterests, removeInterests } = interestsSlice.actions;

export default interestsSlice.reducer;
