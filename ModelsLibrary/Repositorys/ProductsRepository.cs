using ModelsLibrary.DtO_Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Repositorys
{
    public class ProductsRepository
    {
        public void Create(Products model)
        {
            SqlConnection connection = new SqlConnection(
                 "data source=.; database=BuildSchool; integrated security=true");
            var sql = "INSERT INTO Products (ProductID,ProductName,CategoryID,UnitPrice,UnitsInStock,Size,Color,Uptime) VALUES (@ProductID,@ProductName,@CategoryID,@UnitPrice,@UnitsInStock,@Size,@Color,@Uptime)";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@ProductID", model.ProductID);
            command.Parameters.AddWithValue("@ProductName", model.ProductName);
            command.Parameters.AddWithValue("@CategoryID", model.CategoryID);
            command.Parameters.AddWithValue("@UnitPrice", model.UnitPrice);
            command.Parameters.AddWithValue("@UnitsInStock", model.UnitsInStock);
            command.Parameters.AddWithValue("@Size", model.Size);
            command.Parameters.AddWithValue("@Color", model.Color);
            command.Parameters.AddWithValue("@Uptime", model.Uptime);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateUnitPrice(Products model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "UPDATE Products SET UnitPrice=@UnitPrice WHERE ProductID=@ProductID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@ProductID", model.ProductID);
            command.Parameters.AddWithValue("@UnitPrice", model.UnitPrice);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateStock(Products model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "UPDATE Products SET UnitsInStock=@UnitsInStock WHERE ProductID=@ProductID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@ProductID", model.ProductID);
            command.Parameters.AddWithValue("@UnitsInStock", model.UnitsInStock);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateDowntime(Products model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "UPDATE Products SET Downtime=@Downtime WHERE ProductID=@ProductID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@ProductID", model.ProductID);
            command.Parameters.AddWithValue("@Downtime", model.Downtime);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        //public void Delete(Products model)
        //{
        //    SqlConnection connection = new SqlConnection(
        //        "data source=.; database=BuildSchool; integrated security=true");
        //    var sql = "DELETE FROM Products WHERE ProductID = @ProductID";

        //    SqlCommand command = new SqlCommand(sql, connection);

        //    command.Parameters.AddWithValue("@ProductID", model.ProductID);

        //    connection.Open();
        //    command.ExecuteNonQuery();
        //    connection.Close();
        //}

        public Products FindByID(string productid)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "SELECT * FROM Products WHERE ProductID = @ProductID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@ProductID", productid);

            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var properties = typeof(Products).GetProperties();
            Products products = null;

            while (reader.Read())
            {
                products=new Products();
                for(var i = 0; i < reader.FieldCount; i++)
                {
                    var fieldName = reader.GetName(i);
                    var property = properties.FirstOrDefault(p => p.Name == fieldName);

                    if (property == null) continue;

                    if (!reader.IsDBNull(i)) property.SetValue(products, reader.GetValue(i));
                }
            }

            reader.Close();

            return products;            
        }

        public IEnumerable<Products> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "SELECT * FROM Products";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var products = new List<Products>();
            Products product = null;

            while (reader.Read())
            {
                product = new Products();
                product.ProductID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ProductID")));
                product.ProductName = Convert.ToString(reader.GetValue(reader.GetOrdinal("ProductName")));
                product.CategoryID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("CategoryID")));
                product.UnitPrice = Convert.ToDecimal(reader.GetValue(reader.GetOrdinal("UnitPrice")));
                product.UnitsInStock = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("UnitsInStock")));
                product.Size = Convert.ToString(reader.GetValue(reader.GetOrdinal("Size")));
                product.Uptime = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("Uptime")));

                if (!reader.IsDBNull(reader.GetOrdinal("Downtime")))
                {
                    product.Downtime = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("Downtime")));
                }
                products.Add(product);
            }

            reader.Close();

            return products;

        }
    }
}
