namespace base_user_management
{
    public static partial class Utils
    {
        public static string GetFirstLastName(string firstName, string lastName, string displayName = "")
        {
            if (string.IsNullOrWhiteSpace(displayName) == false)
            {
                return displayName;
            }

            if (string.IsNullOrWhiteSpace(lastName) == false
            && string.IsNullOrWhiteSpace(firstName) == false)
            {
                return firstName + " " + lastName;
            }

            if (string.IsNullOrWhiteSpace(firstName) == false
            && string.IsNullOrWhiteSpace(lastName) == true)
            {
                return firstName;
            }

            if (string.IsNullOrWhiteSpace(lastName) == false
            && string.IsNullOrWhiteSpace(firstName) == true)
            {
                return lastName;
            }

            return "";
        }
    }
}
