using ADSInvest.Data;
using ADSInvest.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace ADSInvest.Services.Data
{
    public sealed class AuthorizationService
    {
        public static bool UserIsExist(string login, string password)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT * FROM ADSInvestUsers WHERE " +
                    "Login = @Login AND Password = @Password", db.getConnection());
                command.Parameters.Add("@Login", MySqlDbType.VarChar).Value = login;
                command.Parameters.Add("@Password", MySqlDbType.VarChar).Value = password;
                adapter.SelectCommand = command;
                adapter.Fill(table);

                return table.Rows.Count > 0;
            }
        }

        public static UserModel FindByLoginAndPassword(string login, string password)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM ADSInvestUsers WHERE Login = @Login AND Password = @Password", db.getConnection());
                cmd.Parameters.Add("@Login", MySqlDbType.VarChar).Value = login;
                cmd.Parameters.Add("@Password", MySqlDbType.VarChar).Value = password;

                db.openConnection();

                using (MySqlDataReader read = cmd.ExecuteReader())
                {
                    if (!read.Read()) { }

                    UserModel outData = new UserModel()
                    {
                        Id = (int)read["Id"],
                        Login = (string)read["Login"],
                        Password = (string)read["Password"],
                        IsAdmin = (bool)read["IsAdmin"],
                    };

                    db.closeConnection();
                    return outData;
                }
            }
        }
    }
}
