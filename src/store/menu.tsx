import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import IMenuState from "../interfaces/menu/IMenuState";

const initialState: IMenuState = {
  isVisible: false,
};

const mneuSlice = createSlice({
  name: "menu",
  initialState: initialState,
  reducers: {
    makeMenuVisible: (state) => {
      state.isVisible = true;
    },
    makeMenuInvisible: (state) => {
      state.isVisible = false;
    },
  },
});

export const { makeMenuInvisible, makeMenuVisible } = mneuSlice.actions;

export default mneuSlice.reducer;
