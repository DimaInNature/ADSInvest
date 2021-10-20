using ADSInvest.Interfaces.Data;
using ADSInvest.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ADSInvest.Data
{
    public sealed class ConstructionWorkCRUD : ICRUD<ConstructionWorkModel>
    {
        public bool Create(ConstructionWorkModel work)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                MySqlCommand command = new MySqlCommand("INSERT INTO ADSInvestConstructionWorks (Name, " +
                $"Status, EndDate, IdClient, Address) VALUES (N'{work.Name}', N'{work.Status}', " +
                $"@EndDate, {work.IdClient}, N'{work.Address}')", db.getConnection());

                command.Parameters.Add("@EndDate", MySqlDbType.Date).Value = work.EndDate;

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
                MySqlCommand command = new MySqlCommand($"DELETE FROM ADSInvestConstructionWorks WHERE Id = {id}", db.getConnection());

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

        public bool DeleteByIdClient(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                MySqlCommand command = new MySqlCommand($"DELETE FROM ADSInvestConstructionWorks WHERE IdClient = {id}", db.getConnection());

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

        public ConstructionWorkModel ReadById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                MySqlCommand command = new MySqlCommand($"SELECT * FROM ADSInvestConstructionWorks WHERE Id = {id}", db.getConnection());

                db.openConnection();

                using (MySqlDataReader read = command.ExecuteReader())
                {
                    if (read.Read())
                    {
                        ConstructionWorkModel outData = new ConstructionWorkModel()
                        {
                            Id = (int)read["Id"],
                            Name = (string)read["Name"],
                            Status = (string)read["Status"],
                            EndDate = (DateTime)read["EndDate"],
                            Address = (string)read["Address"],
                            IdClient = (int)read["IdClient"]
                        };

                        var clientCRUD = new ClientCRUD();

                        outData.EndDateString = outData.EndDate.ToString("dd/MM/yyyy");

                        outData.Client = clientCRUD.ReadById(outData.IdClient);

                        db.closeConnection();

                        return outData;
                    }
                    else
                    {
                        return null;
                    }

                }
            }
        }

        public IEnumerable<ConstructionWorkModel> ReadAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM ADSInvestConstructionWorks", db.getConnection());

                db.openConnection();

                using (MySqlDataReader read = command.ExecuteReader())
                {
                    while (true)
                    {
                        if (!read.Read()) break;

                        ConstructionWorkModel outData = new ConstructionWorkModel()
                        {
                            Id = (int)read["Id"],
                            Name = (string)read["Name"],
                            Status = (string)read["Status"],
                            EndDate = (DateTime)read["EndDate"],
                            Address = (string)read["Address"],
                            IdClient = (int)read["IdClient"]
                        };

                        var clientCRUD = new ClientCRUD();

                        outData.EndDateString = outData.EndDate.ToString("dd/MM/yyyy");

                        outData.Client = clientCRUD.ReadById(outData.IdClient);

                        yield return outData;
                    }
                }

                db.closeConnection();
            }
        }

        public bool Update(ConstructionWorkModel work)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                MySqlCommand command = new MySqlCommand("UPDATE ADSInvestConstructionWorks SET " +
                $"Name = N'{work.Name}', Status = N'{work.Status}', EndDate = @EndDate, Address =  N'{work.Address}', " +
                $"IdClient = N'{work.IdClient}' WHERE ADSInvestConstructionWorks.Id = {work.Id}", db.getConnection());

                command.Parameters.Add("@EndDate", MySqlDbType.Date).Value = work.EndDate;
                
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
    }
}
