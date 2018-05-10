using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ModelsLibrary.DtO_Models;

namespace ModelsLibrary.Repository
{
   public class CustomerRepository
    {
        public void Cterae(Customer model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.;database=build school;integrated security=true");
            var sql = "INSERT INTO Customers VALUES(@CustomerID,@CustomerName,@Birthday,@Password,@ShoppingCasg,@Account,@Email,@Phone)";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@CustomerID", model.CustomerID);
            command.Parameters.AddWithValue("@CustomerName", model.CustomerName);
            command.Parameters.AddWithValue("@Birthday", model.Birthday);
            command.Parameters.AddWithValue("@Account", model.Account);
            command.Parameters.AddWithValue("@Password", model.Password);
            command.Parameters.AddWithValue("@ShoppingCash", model.ShoppingCash);
            command.Parameters.AddWithValue("@Email", model.Email);
            command.Parameters.AddWithValue("@Phone", model.Phone);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Customer model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.;database=build school;integrated security=true");
            var sql = "UPDATE Customers SET CustomerName=@CustomerName,Birthday=@Birthday,Account=@Account,Password=@Password,ShoppingCasg=@ShoppingCasg,Email=@Email,Phone=@Phone WHERE CustomerID=@CustomerID";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@CustomerID", model.CustomerID);
            command.Parameters.AddWithValue("@CustomerName", model.CustomerName);
            command.Parameters.AddWithValue("@Birthday", model.Birthday);
            command.Parameters.AddWithValue("@Account", model.Account);
            command.Parameters.AddWithValue("@Password", model.Password);
            command.Parameters.AddWithValue("@ShoppingCash", model.ShoppingCash);
            command.Parameters.AddWithValue("@Email", model.Email);
            command.Parameters.AddWithValue("@Phone", model.Phone);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(Customer model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.;database=build school;integrated security=true");
            var sql = "DELETE FROM Customers WHERE CustomerID=@CustomerID";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@CustomerID", model.CustomerID);
            
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public Customer FindById(string customerId)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.;database=build school;integrated security=true");
            var sql = "SELECT * FROM Customers WHERE CustomerID=@CustomerID";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@CustomerID", customerId);

            connection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var customer = new Customer();
            while (reader.Read())
            {
                customer.CustomerID = Convert.ToInt16(reader.GetValue(reader.GetOrdinal("CustomerID")));
                customer.CustomerName = reader.GetValue(reader.GetOrdinal("CustomerName")).ToString();
                customer.Birthday = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("Birthday")).ToString());
                customer.Account = reader.GetValue(reader.GetOrdinal("Account")).ToString();
                customer.Password = reader.GetValue(reader.GetOrdinal("Password")).ToString();
                customer.ShoppingCash =Convert.ToDecimal(reader.GetValue(reader.GetOrdinal("ShoppingCash")));
                customer.Password = reader.GetValue(reader.GetOrdinal("Email")).ToString();
                customer.Password = reader.GetValue(reader.GetOrdinal("Phone")).ToString();
            }
            reader.Close();
            return customer;
        }

        public IEnumerable<Customer> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "data source=.;database=build school;integrated security=true");
            var sql = "SELECT * FROM Customers WHERE CustomerID=@CustomerID";
            SqlCommand command = new SqlCommand(sql, connection);
        
            connection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var customers = new List<Customer>();
            while (reader.Read())
            {
                var customer = new Customer();
                customer.CustomerID = Convert.ToInt16(reader.GetValue(reader.GetOrdinal("CustomerID")));
                customer.CustomerName = reader.GetValue(reader.GetOrdinal("CustomerName")).ToString();
                customer.Birthday = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("Birthday")).ToString());
                customer.Account = reader.GetValue(reader.GetOrdinal("Account")).ToString();
                customer.Password = reader.GetValue(reader.GetOrdinal("Password")).ToString();
                customer.ShoppingCash = Convert.ToDecimal(reader.GetValue(reader.GetOrdinal("ShoppingCash")));
                customer.Password = reader.GetValue(reader.GetOrdinal("Email")).ToString();
                customer.Password = reader.GetValue(reader.GetOrdinal("Phone")).ToString();
            }
            reader.Close();
            return customers;
        }
    }
}
