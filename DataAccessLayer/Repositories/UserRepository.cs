using EntityLayer.Concrete;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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

		//public List<User> GetAllUsersWithRoles()
		//{
		//	using (var connection = new SqlConnection(connectionString))
		//	{
		//		var userDict = new Dictionary<int,User>();
		//		var sql = @"
        //      SELECT u.Id as UserID, u.UserName, r.Id as RoleID, r.RoleName
        //      FROM Users u
        //      LEFT JOIN UserRole ur ON u.Id = ur.UserID
        //      LEFT JOIN Roles r ON ur.RoleID = r.Id";
		//		var User = connection.Query<User, Role, User>(
		//			sql,
		//			(user, role) =>
		//			{
		//				if (!userDict.TryGetValue(user.Id, out var currentUser))
		//				{
		//					currentUser = user;
		//					currentUser.Roles = new List<Role>();
		//					userDict.Add(currentUser.Id, currentUser);
		//				}

		//				if (role != null)
		//				{
		//					currentUser.Roles.Add(role);
		//				}

		//				return currentUser;
		//			},
		//			splitOn: "RoleID"
		//		).Distinct().ToList();

		//		return User;
		//	}
		//}

		//public void UpdateUser(User user)
		//{
		//	_context.Entry(user).OriginalValues["RowVersion"] = user.RowVersion;

		//	try
		//	{
		//		_context.SaveChanges();
		//	}
		//	catch (DbUpdateConcurrencyException ex)
		//	{
		//		var entry = ex.Entries.Single();
		//		var databaseValues = entry.GetDatabaseValues();
		//		if (databaseValues == null)
		//		{
		//			throw new Exception("Bu kayıt başka bir kullanıcı tarafından silinmiş.");
		//		}
		//		else
		//		{
		//			var databaseUser = (User)databaseValues.ToObject();
		//			// Kullanıcıya uyarı gösterebilir veya çakışma çözme mantığını uygulayabilirsiniz
		//			throw new DbUpdateConcurrencyException("Veriler başka bir kullanıcı tarafından güncellenmiş.");
		//		}
		//	}
		}
	}

