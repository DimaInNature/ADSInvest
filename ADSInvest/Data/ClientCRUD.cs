using ADSInvest.Interfaces.Data;
using ADSInvest.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ADSInvest.Data
{
    public sealed class ClientCRUD : ICRUD<ClientModel>
    {
        public bool Create(ClientModel client)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                MySqlCommand command = new MySqlCommand("INSERT INTO ADSInvestClients (Name, Surname, Patronymic, Phone) " +
                $"VALUES ( N'{client.Name}', N'{client.Surname}', N'{client.Patronymic}', N'{client.Phone}')", db.getConnection());

                db.openConnection();

                if (command.ExecuteNonQuery() == 1)
                {
                    db.closeConnection();
                    return true;
                }
                else
                {
                    db.closeConnection();
                    return false;
                }
            }
        }

        public bool Delete(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                MySqlCommand command = new MySqlCommand($"DELETE FROM ADSInvestClients WHERE Id = {id}", db.getConnection());

                db.openConnection();

                if (command.ExecuteNonQuery() == 1)
                {
                    db.closeConnection();
                    return true;
                }
                else
                {
                    db.closeConnection();
                    return false;
                }
            }
        }

        public IEnumerable<ClientModel> ReadAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM ADSInvestClients", db.getConnection());

                db.openConnection();

                using (MySqlDataReader read = command.ExecuteReader())
                {
                    while (true)
                    {
                        if (!read.Read()) break;

                        ClientModel outData = new ClientModel()
                        {
                            Id = (int)read["Id"],
                            Name = (string)read["Name"],
                            Surname = (string)read["Surname"],
                            Patronymic = (string)read["Patronymic"],
                            Phone = (string)read["Phone"]
                        };

                        outData.FullName = $"{outData.Name} {outData.Surname} {outData.Patronymic}";

                        yield return outData;
                    }
                }

                db.closeConnection();
            }
        }

        public bool Update(ClientModel obj)
        {
            return false;
        }

        public ClientModel ReadById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                MySqlCommand command = new MySqlCommand($"SELECT * FROM ADSInvestClients WHERE Id = {id}", db.getConnection());

                db.openConnection();

                using (MySqlDataReader read = command.ExecuteReader())
                {
                    if (!read.Read()) { }

                    ClientModel outData = new ClientModel()
                    {
                        Id = (int)read["Id"],
                        Name = (string)read["Name"],
                        Surname = (string)read["Surname"],
                        Patronymic = (string)read["Patronymic"],
                        Phone = (string)read["Phone"]
                    };

                    outData.FullName = $"{outData.Name} {outData.Surname} {outData.Patronymic}";

                    db.closeConnection();
                    return outData;
                }
            }
        }
    }
}
