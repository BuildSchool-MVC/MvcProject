using ModelsLibrary.DtO_Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Repository
{
    public class OrderDetailsRepository
    {
        public void Create(OrderDetails model)
        {
            SqlConnection connection = new SqlConnection(
                 "data source=.; database=BuildSchool; integrated security=true");
            var sql = "INSERT INTO OrderDetails VALUES (@OrderID, @ProductID, @Quantity)";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@OrderID", model.OrderID);
            command.Parameters.AddWithValue("@ProductID", model.ProductID);
            command.Parameters.AddWithValue("@Quantity", model.Quantity);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(OrderDetails model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "UPDATE OrderDetails SET OrderID=@OrderID, ProductID=@ProductID, Quantity=@Quantity";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@OrderID", model.OrderID);
            command.Parameters.AddWithValue("@ProductID", model.ProductID);
            command.Parameters.AddWithValue("@Quantity", model.Quantity);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(OrderDetails model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "DELETE FROM OrderDetails WHERE Quantity = @Quantity";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Quantity", model.Quantity);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public OrderDetails FindById(string OrderId)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "SELECT * FROM Customers WHERE OrderID=@OrderID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@OrderID", OrderId);

            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var orderdetails = new OrderDetails();

            var properties = typeof(OrderDetails).GetProperties();
            OrderDetails orderdetail = null;

            while (reader.Read())
            {
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var fieldName = reader.GetName(i);
                    var property = properties.FirstOrDefault((p) => p.Name == fieldName);

                    if (property == null) continue;

                    if (!reader.IsDBNull(i)) property.SetValue(orderdetail, reader.GetValue(i));
                }
                //orderdetails.OrderID = (int)reader.GetValue(reader.GetOrdinal("OrderID"));
                //orderdetails.ProductID = (int)reader.GetValue(reader.GetOrdinal("ProductID"));
                //orderdetails.Quantity = (int)reader.GetValue(reader.GetOrdinal("Quantity"));
            }
            reader.Close();
            return orderdetails;
        }

        public IEnumerable<OrderDetails> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=; integrated security=true");
            var sql = "SELECT * FROM OrderDetails";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var orderdetails = new List<OrderDetails>();

            while (reader.Read())
            {
                var orderdetail = new OrderDetails();
                orderdetail.OrderID = (int)reader.GetValue(reader.GetOrdinal("OrderID"));
                orderdetail.ProductID = (int)reader.GetValue(reader.GetOrdinal("ProductID"));
                orderdetail.Quantity = (int)reader.GetValue(reader.GetOrdinal("Quantity"));

                orderdetails.Add(orderdetail);
            }

            reader.Close();

            return orderdetails;

        }
    }
}
