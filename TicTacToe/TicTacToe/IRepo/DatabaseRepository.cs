using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class DatabaseRepository : IRepository
    {
        List<User> AllUsers = new List<User>();
        IRepository repo;
        public void CreateUser(User user)
        {
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = @"Data Source=TAVDESK154;Initial Catalog=TictactoeUser;User Id=sa; Password=test123!@#";
                sqlConnection.Open();
                // string query = "Insert into User( Name , UserName , AccessToken ) values"+"'@name'"+" "+"''"
                string query = "Insert into  UserDetails ( Name , UserName , AccessToken ) values ( @name ,@username , @acesstoken )";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@name", user.Name));
                sqlCommand.Parameters.Add(new SqlParameter("@username", user.UserName));
                sqlCommand.Parameters.Add(new SqlParameter("@acesstoken", user.AccessToken));
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Data Saved");
            }
            catch (SqlException e)
            {
                throw new Exception(e.StackTrace);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public bool IsAccessTokenValid(string AccessToken)
        {
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = @"Data Source=TAVDESK154;Initial Catalog=TictactoeUser;User Id=sa; Password=test123!@#";
                sqlConnection.Open();
                // string query = "Insert into User( Name , UserName , AccessToken ) values"+"'@name'"+" "+"''"
                string query = "select * from UserDetails where AccessToken = '"+AccessToken+"'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    if(AccessToken == reader["AccessToken"].ToString())
                    {
                        return true;
                    }
                }
                return false;

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                sqlConnection.Close();
            }

            return false;
        }
    }
}
