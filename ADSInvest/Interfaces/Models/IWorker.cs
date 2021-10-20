namespace ADSInvest.Interfaces.Models
{
    /// <summary> Рабочий </summary>
    
    public interface IWorker
    {
        int Id { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        string Patronymic { get; set; }
        string Specialization { get; set; }
        string ContactInformation { get; set; }
        int IdConstructionWork { get; set; }
    }
}
