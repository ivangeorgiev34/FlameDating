namespace FlameDating.Infrastructure.Constants
{
    public static class InfrastructureConstants
    {
        public static class User
        {
            public const string FIRST_NAME_REQUIRED_ERROR_MESSAGE = "First name is required";

            public const string MIDDLE_NAME_REQUIRED_ERROR_MESSAGE = "Middle name is required";

            public const string LAST_NAME_REQUIRED_ERROR_MESSAGE = "Last name is required";

            public const string AGE_REQUIRED_ERROR_MESSAGE = "Age is required";
            public const int AGE_MIN_VALUE = 18;
            public const int AGE_MAX_VALUE = 100;
            public const string AGE_VALUE_ERROR_MESSAGE = "Age should be between 18 and 100";

            public const string GENDER_REQUIRED_ERROR_MESSAGE = "Gender is required";
            public const string GENDER_DATA_TYPE_ERROR_MESSAGE = "Gender should be male or female";

            public const string LOCATION_REQUIRED_ERROR_MESSAGE = "Location is required";

            public const string HEIGHT_REQUIRED_ERROR_MESSAGE = "Height is required";
            public const double HEIGHT_MIN_VALUE = 1.20d;
            public const double HEIGHT_MAX_VALUE = 2.50d;
            public const string HEIGHT_VALUE_ERROR_MESSAGE = "Height should be between 1.20 and 2.50";

            public const string FIRST_PROFILE_PICTURE_REQUIRED_ERROR_MESSAGE = "First profile picture is required";

            public const string PREFERENCE_ID_REQUIRED_ERROR_MESSAGE = "Prefference is required";

        }

        public static class Preference
        {
            public const int MAXIMUM_DISTANCE_MIN_VALUE = 2;
            public const int MAXIMUM_DISTANCE_MAX_VALUE = 150;
            public const string MAXIMUM_DISTANCE_VALUE_ERROR_MESSAGE = "Maximum distance should be between 2 km and 150 km";

            public const string GENDER_REQUIRED_ERROR_MESSAGE = "Gender is required";
            public const string GENDER_DATA_TYPE_ERROR_MESSAGE = "Gender should be male or female";
        }

        public static class Interest
        {
            public const string NAME_REQUIRED_ERROR_MESSAGE = "Name is required";
        }

        public static class Like
        {
            public const string LIKE_STATUS_REQUIRED_ERROR_MESSAGE = "Like status is required";
            public const string LIKE_STATUS_DATA_TYPE_ERROR_MESSAGE = "Like status should be like or dislike";

            public const string LIKE_DATE_REQUIRED_ERROR_MESSAGE = "Like date is required";

            public const string LIKER_ID_REQUIRED_ERROR_MESSAGE = "Liker id is required";
            public const string LIKED_ID_REQUIRED_ERROR_MESSAGE = "Liked id is required";
        }

        public static class Match
        {
            public const string MATCH_DATE_REQUIRED_ERROR_MESSAGE = "Match date is required";

            public const string FIRST_USER_ID_REQUIRED_ERROR_MESSAGE = "First user id is required";

            public const string SECOND_USER_ID_REQUIRED_ERROR_MESSAGE = "Second user id is required";

            public const string CHAT_ID_REQUIRED_ERROR_MESSAGE = "Chat id is required";
        }

        public static class Message
        {
            public const string TEXT_REQUIRED_ERROR_MESSAGE = "Text is required";

            public const string DATE_REQUIRED_ERROR_MESSAGE = "Date is required";

            public const string SENDER_USER_ID_REQUIRED_ERROR_MESSAGE = "Sender user id is required";

            public const string RECIEVER_USER_ID_REQUIRED_ERROR_MESSAGE = "Reciever user id is required";
        }

        public static class RegisterDto
        {
            public const string EMAIL_REQUIRED_ERROR_MESSAGE = "Email is required";

            public const string EMAIL_INVALID_ERROR_MESSAGE = "Email is invalid";

            public const string USERNAME_REQUIRED_ERROR_MESSAGE = "Username is required";

            public const string PASSWORD_REQUIRED_ERROR_MESSAGE = "Password is required";

            public const string CONFIRM_PASSWORD_REQUIRED_ERROR_MESSAGE = "Confirm password is required";

            public const string PASSWORDS_COMPARE_ERROR_MESSAGE = "Passwords do not match";
        }
    }
}
