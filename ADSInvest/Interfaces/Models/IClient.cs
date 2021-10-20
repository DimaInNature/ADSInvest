namespace ADSInvest.Interfaces.Models
{
    /// <summary> Заказчик </summary>

    public interface IClient
    {
        int Id { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        string Patronymic { get; set; }
        string Phone { get; set; }
    }
}
