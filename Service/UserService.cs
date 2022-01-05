using SR23_2020_POP2021.Entities;
using SR23_2020_POP2021.Service;
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

            using (SqlConnection connection = new SqlConnection(Util.CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"select * from Users where isDeleted = 0";

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        username = reader.GetString(0),
                        name = reader.GetString(1),
                        surname = reader.GetString(2),
                        gender = (Gender)reader.GetInt32(3),
                        address = AddressService.findOneByID(reader.GetInt32(4)),
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

        public static User findUserByUsername(String username)
        {
            using (SqlConnection connection = new SqlConnection(Util.CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"select * from Users where username = @username and isDeleted = 0";
                command.Parameters.Add(new SqlParameter("username", username));

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return new User
                    {
                        username = reader.GetString(0),
                        name = reader.GetString(1),
                        surname = reader.GetString(2),
                        gender = (Gender)reader.GetInt32(3),
                        address = AddressService.findOneByID(reader.GetInt32(4)),
                        email = reader.GetString(5),
                        password = reader.GetString(6),
                        userRole = (Role)reader.GetInt32(7),
                        isDeleted = reader.GetBoolean(8)
                    };
                }
                reader.Close();
            }
            return null;
        }

        public static void createNewUser(User newUser)
        {
            using (SqlConnection connection = new SqlConnection(Util.CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"insert into Users (username, name, surname, gender, address, email, password, role)
                                        values (@username, @name, @surname, @gender, @address, @email, @password, @role)";
                command.Parameters.Add(new SqlParameter("username", newUser.username));
                command.Parameters.Add(new SqlParameter("name", newUser.name));
                command.Parameters.Add(new SqlParameter("surname", newUser.surname));
                command.Parameters.Add(new SqlParameter("gender", newUser.gender));
                command.Parameters.Add(new SqlParameter("address", newUser.address.id));
                command.Parameters.Add(new SqlParameter("email", newUser.email));
                command.Parameters.Add(new SqlParameter("password", newUser.password));
                command.Parameters.Add(new SqlParameter("role", newUser.userRole));

                SqlDataReader reader = command.ExecuteReader();
            }
        }

        public static void deleteUser(User deleteUser)
        {
            using(SqlConnection connection = new SqlConnection(Util.CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"update Users set isDeleted = 1 where username = @username";
                command.Parameters.Add(new SqlParameter("username", deleteUser.username));
                SqlDataReader reader = command.ExecuteReader();
            }
        }

        public static void editUser(User editedUser)
        {
            using (SqlConnection connection = new SqlConnection(Util.CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"update Users set name = @name, surname = @surname, gender = @gender,
                                       email = @email, password = @password, role = @role where username = @username";
                command.Parameters.Add(new SqlParameter("username", editedUser.username));
                command.Parameters.Add(new SqlParameter("name", editedUser.name));
                command.Parameters.Add(new SqlParameter("surname", editedUser.surname));
                command.Parameters.Add(new SqlParameter("gender", editedUser.gender));
                command.Parameters.Add(new SqlParameter("email", editedUser.email));
                command.Parameters.Add(new SqlParameter("password", editedUser.password));
                command.Parameters.Add(new SqlParameter("role", editedUser.userRole));

                SqlDataReader reader = command.ExecuteReader();
            }
        }
    }

}
