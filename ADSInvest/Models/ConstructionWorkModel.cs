using ADSInvest.Interfaces.Models;
using System;

namespace ADSInvest.Models
{
    public sealed class ConstructionWorkModel : IConstructionWork
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime EndDate { get; set; }
        public string EndDateString { get; set; }
        public string Address { get; set; }
        public int IdClient { get; set; }

        public ClientModel Client { get; set; }
    }
}
