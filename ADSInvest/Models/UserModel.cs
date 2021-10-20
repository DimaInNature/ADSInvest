using ADSInvest.Interfaces.Models;

namespace ADSInvest.Models
{
    public sealed class UserModel : IUser
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public UserModel(string login, string password, bool isAdmin = false)
        {
            Login = login;
            Password = password;
            IsAdmin = isAdmin;
        }

        public UserModel() { }
    }
}
