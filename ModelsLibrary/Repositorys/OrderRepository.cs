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
    public class OrderRepository
    {
        public void Create(Order model)
        {
            SqlConnection connection = new SqlConnection(
                "data source =. ; database = BuildSchool ; integrated security=true");
            var sql = "INSERT INTO [Order] VALUES (@OrderID , @OrderDay , @CustomerID , @Transport , @Payment , @Status)";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@OrderID", model.OrderID);
            command.Parameters.AddWithValue("@OrderDay", model.OrderDay);
            command.Parameters.AddWithValue("@CustomerID", model.CustomerID);
            command.Parameters.AddWithValue("@Transport", model.Transport);
            command.Parameters.AddWithValue("@Payment", model.Payment);
            command.Parameters.AddWithValue("@Status", model.Status);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Order model)
        {
            SqlConnection connection = new SqlConnection(
                "data source =. ; database = BuildSchool ; integrated security=true");
            var sql = "UPDATE [Order] SET OrderDay = @OrderDay , CustomerID = @CustomerID , Transport = @Transport , Payment = @Payment , Status = @Status";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@OrderID", model.OrderID);
            command.Parameters.AddWithValue("@OrderDay", model.OrderDay);
            command.Parameters.AddWithValue("@CustomerID", model.CustomerID);
            command.Parameters.AddWithValue("@Transport", model.Transport);
            command.Parameters.AddWithValue("@Payment", model.Payment);
            command.Parameters.AddWithValue("@Status", model.Status);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(Order model)
        {
            SqlConnection connection = new SqlConnection(
                "data source =. ; database = BuildSchool ; integrated security=true");
            var sql = "DELETE FROM [Order] WHERE OrderID = @OrderID";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@OrderID", model.OrderID);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Order FindById(string orderId)
        {
            SqlConnection connection = new SqlConnection(
                "data source =. ; database = BuildSchool ; integrated security=true");
            var sql = "SELECT * FROM [Order] WHERE OrderID = @OrderID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@OrderID", orderId);

            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            //var order = new Order();
            var properties = typeof(Order).GetProperties();
            Order order = null;


            while (reader.Read())
            {
                order = new Order();
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var fieldName = reader.GetName(i);
                    var property = properties.FirstOrDefault(
                        p => p.Name == fieldName);

                    if (property == null)
                        continue;

                    if (!reader.IsDBNull(i))
                        property.SetValue(order,
                            reader.GetValue(i));
                }

            }

            reader.Close();

            return order;
        }

        public IEnumerable<Order> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                            "data source =.;database =BuildSchool; integrated security=true");
            var sql = "SELECT * FROM [Order]";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var orders = new List<Order>();

            while (reader.Read())
            {
                var order = new Order();
                order.OrderID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("OrderID")).ToString());
                order.OrderDay = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("OrderDay")).ToString());
                order.CustomerID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("CustomerID")).ToString());
                order.Transport = reader.GetValue(reader.GetOrdinal("Transport")).ToString();
                order.Payment = reader.GetValue(reader.GetOrdinal("Payment")).ToString();
                order.Status = reader.GetValue(reader.GetOrdinal("Status")).ToString();
                orders.Add(order);
            }

            reader.Close();

            return orders;

        }
    }
}

