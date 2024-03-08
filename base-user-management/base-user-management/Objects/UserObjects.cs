using System;

namespace base_user_management
{
    public abstract class UserBaseDto
    {
        public string FirstName;
        public string LastName;
        public string DisplayName;
        public string EmailAddress;
    }

    public class UserCreateDto : UserBaseDto
    {
        public string Password;
    } 

    public class User
    {
        public int UserID;
        public string FirstName;
        public string LastName;
        public string DisplayName;
        public string EmailAddress;
        public string ProfileImageLocation;
        public DateTimeOffset CreatedUtc;
        public DateTimeOffset UpdatedUtc;
        public DateTimeOffset LastSignedInUtc;
        public bool IsDeleted;
        public byte[] RowVersion;
    }
}