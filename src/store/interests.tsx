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

      state.interests = produce(state.interests, (draftState) => {
        draftState.push(...action.payload);
      });
    },
    removeInterests: (state) => {
      localStorage.removeItem("interests");

      state.interests = produce(state.interests, (draftState) => {
        draftState.length = 0;
      });
    },
  },
});

export const { addInterests, removeInterests } = interestsSlice.actions;

export default interestsSlice.reducer;
