import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import IAuthState from "../interfaces/auth/IAuthState";

const initialState: IAuthState = {
  id: null,
  firstName: null,
  middleName: null,
  lastName: null,
  age: null,
  email: null,
  username: null,
  gender: null,
  biography: null,
  school: null,
  job: null,
  height: null,
  firstProfilePicture: null,
  secondProfilePicture: null,
  thirdProfilePicture: null,
  fourthProfilePicture: null,
  fifthProfilePicture: null,
  token: null,
  expires: null,
};

const authSlice = createSlice({
  name: "auth",
  initialState: initialState,
  reducers: {
    login: (state, action: PayloadAction<IAuthState>) => {
      state.id = action.payload.id;
      state.firstName = action.payload.firstName;
      state.middleName = action.payload.middleName;
      state.lastName = action.payload.lastName;
      state.age = action.payload.age;
      state.email = action.payload.email;
      state.username = action.payload.username;
      state.gender = action.payload.gender;
      state.biography = action.payload.biography;
      state.school = action.payload.school;
      state.job = action.payload.job;
      state.height = action.payload.height;
      state.firstProfilePicture = action.payload.firstProfilePicture;
      state.secondProfilePicture = action.payload.secondProfilePicture;
      state.thirdProfilePicture = action.payload.thirdProfilePicture;
      state.fourthProfilePicture = action.payload.fourthProfilePicture;
      state.fifthProfilePicture = action.payload.fifthProfilePicture;
      state.token = action.payload.token;
      state.expires = action.payload.expires;

      localStorage.setItem("auth", JSON.stringify(action.payload));
    },
    logout: (state) => {
      state.id = null;
      state.firstName = null;
      state.middleName = null;
      state.lastName = null;
      state.age = null;
      state.email = null;
      state.username = null;
      state.gender = null;
      state.biography = null;
      state.school = null;
      state.job = null;
      state.height = null;
      state.firstProfilePicture = null;
      state.secondProfilePicture = null;
      state.thirdProfilePicture = null;
      state.fourthProfilePicture = null;
      state.fifthProfilePicture = null;
      state.token = null;
      state.expires = null;

      localStorage.removeItem("auth");
    },
  },
});

export const { login, logout } = authSlice.actions;

export default authSlice.reducer;
