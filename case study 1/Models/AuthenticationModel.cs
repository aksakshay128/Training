namespace WebApplicationProject.Models
{
    public class LoginModel
    {

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }

    }

    public class UserModel
    {

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

    }
}
