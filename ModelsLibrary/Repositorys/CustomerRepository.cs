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
                "data source=.;database=BuildSchool;integrated security=true");
            var sql = "INSERT INTO Customer VALUES(@CustomerID,@CustomerName,@Birthday,@Password,@ShoppingCasg,@Account,@Email,@Phone)";
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
                "data source=.;database=BuildSchool;integrated security=true");
            var sql = "UPDATE Customer SET CustomerName=@CustomerName,Password=@Password,ShoppingCasg=@ShoppingCasg,Email=@Email,Phone=@Phone WHERE CustomerID=@CustomerID";
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
                "data source=.;database=BuildSchool;integrated security=true");
            var sql = "DELETE FROM Customer WHERE CustomerID=@CustomerID";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@CustomerID", model.CustomerID);
            
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public Customer FindById(int customerId)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.;database=BuildSchool;integrated security=true");
            var sql = "SELECT * FROM Customer WHERE CustomerID=@CustomerID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@CustomerID", customerId);
            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var customer = new Customer();

            while (reader.Read())
            {
                customer.CustomerID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("CustomerID")));
                customer.CustomerName = reader.GetValue(reader.GetOrdinal("CustomerName")).ToString();
                customer.Birthday = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("Birthday")).ToString());
                customer.Account = reader.GetValue(reader.GetOrdinal("Account")).ToString();
                customer.Password = reader.GetValue(reader.GetOrdinal("Password")).ToString();
                customer.ShoppingCash = Convert.ToDecimal(reader.GetValue(reader.GetOrdinal("ShoppingCash")));
                customer.Email = reader.GetValue(reader.GetOrdinal("Email")).ToString();
                customer.Phone = reader.GetValue(reader.GetOrdinal("Phone")).ToString();
            }

            reader.Close();

            return customer;
            // var properties = typeof(Customer).GetProperties();
            // var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            //// var customer = new Customer();
            // Customer customer = null;
            // while (reader.Read())
            // {
            //     for (var i = 0; i < reader.FieldCount; i++)
            //     {
            //         customer = new Customer();
            //         var fieldName = reader.GetName(i);
            //         var property = properties.FirstOrDefault(p => p.Name == fieldName);

            //         if (property == null)
            //             continue;

            //         if (!reader.IsDBNull(i))
            //             property.SetValue(customer, reader.GetValue(i));
            //     }
            // }
            // reader.Close();
            // return customer;
        }

        public IEnumerable<Customer> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "data source=.;database=BuildSchool;integrated security=true");
            var sql = "SELECT * FROM Customer";
            SqlCommand command = new SqlCommand(sql, connection);
        
            connection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var customers = new List<Customer>();
            while (reader.Read())
            {
                var customer = new Customer();
                customer.CustomerID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("CustomerID")));
                customer.CustomerName = reader.GetValue(reader.GetOrdinal("CustomerName")).ToString();
                customer.Birthday = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("Birthday")).ToString());
                customer.Account = reader.GetValue(reader.GetOrdinal("Account")).ToString();
                customer.Password = reader.GetValue(reader.GetOrdinal("Password")).ToString();
                customer.ShoppingCash = Convert.ToDecimal(reader.GetValue(reader.GetOrdinal("ShoppingCash")));
                customer.Email = reader.GetValue(reader.GetOrdinal("Email")).ToString();
                customer.Phone = reader.GetValue(reader.GetOrdinal("Phone")).ToString();

                customers.Add(customer);
            }
            reader.Close();
            return customers;
        }

        public Customer FindProductsByCustomerID(int customerId)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.;database=BuildSchool;integrated security=true");
            var sql = "select p.ProductName,sd.Quantity,p.Size,p.Color from Customer c inner join [Shoppingcart Details] as sd on sd.CustomerID = c.CustomerID inner join Products as p on p.ProductID = sd.ProductID where c.CustomerID = @CustomerID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@CustomerID", customerId);
            connection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
           // var customers = new List<Customer>();
            var customer = new Customer();
             while (reader.Read())
            {
               // var customer = new Customer();
                var Products = new Products();
                customer.CustomerName = reader.GetValue(reader.GetOrdinal("CustomerName")).ToString();
                Products.ProductID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ProductID")));

               // customers.Add(customer);
            }
            reader.Close();
            return customer;

        }
    }
}
