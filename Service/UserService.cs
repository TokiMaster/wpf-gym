using SR23_2020_POP2021.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR23_2020_POP2021.Servisi
{
    public class UserService
    {

        public static List<User> ReadUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection conn = new SqlConnection(Util.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"select * from dbo.Users";

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        username = reader.GetString(0),
                        name = reader.GetString(1),
                        surname = reader.GetString(2),
                        //address = reader.GetInt32(3),
                        gender = (Gender)reader.GetInt32(4),
                        email = reader.GetString(5),
                        password = reader.GetString(6),
                        userRole = (Role)reader.GetInt32(7),
                        isDeleted = reader.GetBoolean(8)
                    });
                }
                reader.Close();
            }
            return users;
        }
    }
}
