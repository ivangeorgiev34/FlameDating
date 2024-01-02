export default interface IRegisterForm {
  firstName: string;
  middleName: string;
  lastName: string;
  age: number;
  gender: string;
  height: number;
  school: string;
  job: string;
  biography: string;
  firstProfilePicture: File | null;
  secondProfilePicture: File | null;
  thirdProfilePicture: File | null;
  fourthProfilePicture: File | null;
  fifthProfilePicture: File | null;
  maximumDistance: number;
  preferedGender: string;
  email: string;
  username: string;
  password: string;
  confirmPassword: string;
  locationLatitude: number;
  locationLongitude: number;
}
