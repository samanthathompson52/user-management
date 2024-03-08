using Microsoft.AspNetCore.Mvc;

namespace base_user_management
{
    public class UserController : BaseController
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAll")]
        public ActionResult GetAll()
        {
            List<User> users = new List<User>
            {
                new User
                {
                    UserID = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    DisplayName = "John Doe",
                    EmailAddress = ""
                }
            };
               
                
            return Ok(users);
        }
    }
}
