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
    public class CategoriesRepository
    {
        public void Create(Categories model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool_new; integrated security=true");
            var sql = "INSERT INTO Categories VALUES (@Cid, @Cname)";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Cid", model.CategoryID);
            command.Parameters.AddWithValue("@Cname", model.CategoryName);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(Categories model)
        {
            SqlConnection connection = new SqlConnection(
               "data source=.; database=BuildSchool_new; integrated security=true");
            var sql = "DELETE FROM Categories WHERE CategoryID = @Cid";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Cid", model.CategoryID);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateCategoryName(Categories model_1, Categories model_2)
        {
            SqlConnection connection = new SqlConnection(
              "data source=.; database=BuildSchool_new; integrated security=true");
            var sql = "UPDATE Categories SET CategoryName = @inputCName WHERE CategoryName = @SearchCName";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SearchCName", model_1.CategoryName);
            command.Parameters.AddWithValue("@inputCName", model_2.CategoryName);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void GetByID(Categories model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "SELECT * FROM Categories WHERE CategoryID = @CId";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Cid", model.CategoryID);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
