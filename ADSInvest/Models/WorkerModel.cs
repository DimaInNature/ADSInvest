using ADSInvest.Interfaces.Models;

namespace ADSInvest.Models
{
    public sealed class WorkerModel : IWorker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Specialization { get; set; }
        public string ContactInformation { get; set; }
        public int IdConstructionWork { get; set; }

        public IConstructionWork Construction { get; set; }
        public string FullName { get; set; }
    }
}
