using ADSInvest.Interfaces.Models;

namespace ADSInvest.Models
{
    public sealed class ClientModel : IClient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }

        public string FullName { get; set; }
    }
}