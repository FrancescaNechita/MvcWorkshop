using System.Collections.Generic;

namespace Centric.Internship.Mvc.Storage
{
    public class UserStorage
    {
        public static List<User> Users = new List<User>
        {
            new User()
            {
                Name = "admin",
                Login = "admin",
                Password = "admin",
                Role = "admin"
            },
            new User()
            {
                Name = "user",
                Login = "user",
                Password = "user",
                Role = "user"
            }
        };
    }
}