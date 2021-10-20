using ADSInvest.Interfaces.Data;
using ADSInvest.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ADSInvest.Data
{
    public sealed class ProductCRUD : ICRUD<ProductModel>
    {
        public bool Create(ProductModel product)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                MySqlCommand command = new MySqlCommand("INSERT INTO ADSInvestProducts (Name, " +
                $"UnitOfMeasurement, PricePerUnit, Quantity) VALUES (N'{product.Name}', N'{product.UnitOfMeasurement}', " +
                $"{product.PricePerUnit}, {product.Quantity})", db.getConnection());

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
                MySqlCommand command = new MySqlCommand($"DELETE FROM ADSInvestProducts WHERE Id = {id}", db.getConnection());

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

        public IEnumerable<ProductModel> ReadAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM ADSInvestProducts", db.getConnection());

                db.openConnection();

                using (MySqlDataReader read = command.ExecuteReader())
                {
                    while (true)
                    {
                        if (!read.Read()) break;

                        ProductModel outData = new ProductModel()
                        {
                            Id = (int)read["Id"],
                            Name = (string)read["Name"],
                            UnitOfMeasurement = (string)read["UnitOfMeasurement"],
                            PricePerUnit = (double)read["PricePerUnit"],
                            Quantity = (int)read["Quantity"]
                        };

                        outData.FormatQuantityString = $"{outData.Quantity} {outData.UnitOfMeasurement}";
                        outData.FormatPricePerUnitString = $"{outData.PricePerUnit}р. за 1 {outData.UnitOfMeasurement}";

                        yield return outData;
                    }
                }

                db.closeConnection();
            }
        }

        public bool Update(ProductModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
