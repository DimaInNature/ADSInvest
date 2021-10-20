using ADSInvest.Interfaces.Data;
using ADSInvest.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ADSInvest.Data
{
    public sealed class WorkerCRUD : ICRUD<WorkerModel>
    {
        public bool Create(WorkerModel worker)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                MySqlCommand command = new MySqlCommand("INSERT INTO ADSInvestWorkers (Name, " +
                $"Surname, Patronymic, Specialization, ContactInformation, IdConstructionWork) VALUES (N'{worker.Name}', N'{worker.Surname}', " +
                $"N'{worker.Patronymic}', N'{worker.Specialization}', N'{worker.ContactInformation}', N'{worker.IdConstructionWork}')",
                db.getConnection());

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
                MySqlCommand command = new MySqlCommand($"DELETE FROM ADSInvestWorkers WHERE Id = {id}", db.getConnection());

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

        public bool DeleteByIdConstructionWork(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                MySqlCommand command = new MySqlCommand($"DELETE FROM ADSInvestWorkers WHERE IdConstructionWork = {id}", db.getConnection());

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

        public IEnumerable<WorkerModel> ReadAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM ADSInvestWorkers", db.getConnection());

                db.openConnection();

                using (MySqlDataReader read = command.ExecuteReader())
                {
                    while (true)
                    {
                        if (!read.Read()) break;

                        WorkerModel outData = new WorkerModel()
                        {
                            Id = (int)read["Id"],
                            Name = (string)read["Name"],
                            Surname = (string)read["Surname"],
                            Patronymic = (string)read["Patronymic"],
                            Specialization = (string)read["Specialization"],
                            ContactInformation = (string)read["ContactInformation"],
                            IdConstructionWork = (int)read["IdConstructionWork"]
                        };

                        outData.FullName = $"{outData.Name} {outData.Surname} {outData.Patronymic}";

                        var _constructionWorkCRUD = new ConstructionWorkCRUD();

                        outData.Construction = _constructionWorkCRUD.ReadById(outData.IdConstructionWork);

                        yield return outData;
                    }
                }

                db.closeConnection();
            }
        }

        public IEnumerable<WorkerModel> ReadAllByIdConstructionWork(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                MySqlCommand command = new MySqlCommand($"SELECT * FROM ADSInvestWorkers WHERE IdConstructionWork = {id}", db.getConnection());

                db.openConnection();

                using (MySqlDataReader read = command.ExecuteReader())
                {
                    while (true)
                    {
                        if (!read.Read()) break;

                        WorkerModel outData = new WorkerModel()
                        {
                            Id = (int)read["Id"],
                            Name = (string)read["Name"],
                            Surname = (string)read["Surname"],
                            Patronymic = (string)read["Patronymic"],
                            Specialization = (string)read["Specialization"],
                            ContactInformation = (string)read["ContactInformation"],
                            IdConstructionWork = (int)read["IdConstructionWork"]
                        };

                        outData.FullName = $"{outData.Name} {outData.Surname} {outData.Patronymic}";

                        var _constructionWorkCRUD = new ConstructionWorkCRUD();

                        outData.Construction = _constructionWorkCRUD.ReadById(outData.IdConstructionWork);

                        yield return outData;
                    }
                }

                db.closeConnection();
            }
        }

        public bool Update(WorkerModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
