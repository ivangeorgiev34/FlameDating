export default interface IResponse {
  status: "Success" | "Error";
  message: string;
  content?: string | null;
}
