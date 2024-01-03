export const firstProfilePictureValidation = (profilePicture: File | null) => {
  return profilePicture === null ? "First profile picture is required" : "";
};
