namespace Centric.Internship.Mvc.Storage
{
    public class User
    {
        public string Name { get; internal set; }
        public string Login { get; internal set; }
        public string Password { get; internal set; }
        public string Role { get; internal set; }
    }
}