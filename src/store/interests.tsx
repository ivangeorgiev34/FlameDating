import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import IInterestsState from "../interfaces/interests/IInterestsState/IInterestsState";
import IInterest from "../interfaces/interests/IInterest/IInterest";

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
      console.log(action.payload);
      state.interests = action.payload;

      localStorage.setItem("interests", JSON.stringify(action.payload));
    },
    removeInterests: (state) => {
      state.interests = [];

      localStorage.removeItem("interests");
    },
  },
});

export const { addInterests, removeInterests } = interestsSlice.actions;

export default interestsSlice.reducer;
