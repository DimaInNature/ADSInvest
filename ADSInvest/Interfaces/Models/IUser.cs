namespace ADSInvest.Interfaces.Models
{
    /// <summary> Пользователь </summary>
    
    public interface IUser
    {
        int Id { get; set; }
        string Login { get; set; }
        string Password { get; set; }
        bool IsAdmin { get; set; }
    }
}
