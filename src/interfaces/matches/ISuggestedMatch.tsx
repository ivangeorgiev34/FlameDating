export default interface ISuggestedMatch {
  id: string;
  firstName: string;
  middleName: string;
  lastName: string;
  age: number;
  email: string;
  username: string;
  gender: 0 | 1;
  biography: string | null;
  school: string | null;
  distanceFromUser: number | null;
  job: string | null;
  height: number;
  firstProfilePicture: string;
  secondProfilePicture: string | null;
  thirdProfilePicture: string | null;
  fourthProfilePicture: string | null;
  fifthProfilePicture: string | null;
}
