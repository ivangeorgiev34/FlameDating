export default interface IAuthState {
  id: string | null;
  firstName: string | null;
  middleName: string | null;
  lastName: string | null;
  age: number | null;
  email: string | null;
  username: string | null;
  gender: "Male" | "Female" | null;
  biography: string | null;
  school: string | null;
  job: string | null;
  height: number | null;
  firstProfilePicture: string | null;
  secondProfilePicture: string | null;
  thirdProfilePicture: string | null;
  fourthProfilePicture: string | null;
  fifthProfilePicture: string | null;
  token: string | null;
  expires: string | null;
}
