namespace base_user_management
{
    public class SignInDto
    {
        public string EmailAddress = "";
        public string Password = "";
    }

    public class SignInResponseDto
    {
        public int UserID;
        public int CaregiverID;
        public string AuthToken = "";
        public string EmailAddress = "";
        public string FirstName = "";
        public string LastName = "";
        public string DisplayName = "";

        public string FirstLastName
        {
            get
            {
                return Utils.GetFirstLastName(FirstName, LastName, DisplayName);
            }
        }
    }
}
