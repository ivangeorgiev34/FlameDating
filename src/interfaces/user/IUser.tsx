export default interface IUser {
  id: string;
  firstName: string;
  middleName: string;
  lastName: string;
  age: number;
  gender: number;
  height: number;
  school: string | null;
  job: string | null;
  biography: string | null;
  locationLatitude: number;
  locationLongitude: number;
  firstProfilePicture: string;
  secondProfilePicture: string | null;
  thirdProfilePicture: string | null;
  fourthProfilePicture: string | null;
  fifthProfilePicture: string | null;
}
