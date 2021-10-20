using System;

namespace ADSInvest.Interfaces.Models
{
    /// <summary> Строительная работа </summary>

    public interface IConstructionWork
    {
        int Id { get; set; }
        string Name { get; set; }
        string Status { get; set; }
        DateTime EndDate { get; set; }
        string Address { get; set; }
        int IdClient { get; set; }
    }
}
