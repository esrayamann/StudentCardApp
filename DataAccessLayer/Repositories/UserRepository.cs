using EntityLayer.Concrete;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
	public class UserRepository
	{
        private string connectionString = "your_connection_string_here";

		public static User GetUserByEmailAndPasssword(string email, string password)//
		{
			throw new NotImplementedException();
		}

		public User GetUserByEmailAndPassword(string email, string password)
		{
			string query = "SELECT * FROM Users WHERE Email = @Email AND Password = @Password";
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@Email", email);
				command.Parameters.AddWithValue("@Password", password);

				try
				{
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							return new User
							{
								Id = (int)reader["Id"],
								Email = reader["Email"].ToString(),
								Sifre = reader["Password"].ToString()
							};
						}
					}
				}
				catch (Exception ex)
				{
					throw new Exception("Veritabanı bağlantı hatası: " + ex.Message);
				}
			}
			return null;
		}
	}
}
