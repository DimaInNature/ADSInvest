using ADSInvest.Interfaces.Data;
using ADSInvest.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ADSInvest.Data
{
    public sealed class UserCRUD : ICRUD<UserModel>
    {
        public bool Create(UserModel user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                MySqlCommand command = new MySqlCommand("INSERT INTO ADSInvestUsers (Login, Password, IsAdmin) " +
                $"VALUES ( N'{user.Login}', N'{user.Password}', @IsAdmin)", db.getConnection());

                command.Parameters.Add("@IsAdmin", MySqlDbType.Byte).Value = user.IsAdmin;

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
            throw new System.NotImplementedException();
        }

        public IEnumerable<UserModel> ReadAll()
        {
            throw new System.NotImplementedException();
        }

        public bool Update(UserModel obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
