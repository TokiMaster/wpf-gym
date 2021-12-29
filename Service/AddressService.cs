using SR23_2020_POP2021.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR23_2020_POP2021.Service
{
    public class AddressService
    {
        public static List<Address> ReadAddresses()
        {
            List<Address> addresses = new List<Address>();

            using (SqlConnection connection = new SqlConnection(Util.CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"select * from Address where isDeleted = 0";

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    addresses.Add(new Address
                    {
                        id = reader.GetInt32(0),
                        streetName = reader.GetString(1),
                        streetNumber = reader.GetInt32(2),
                        city = reader.GetString(3),
                        country = reader.GetString(4),
                        isDeleted = reader.GetBoolean(5)
                    });
                }
                reader.Close();
            }
            return addresses;
        }

        public static Address findOneByID(int id)
        {
            using (SqlConnection connection = new SqlConnection(Util.CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"select * from Address where id = @id and isDeleted = 0";
                command.Parameters.Add(new SqlParameter("id", id));
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Address
                        {
                            id = reader.GetInt32(0),
                            streetName = reader.GetString(1),
                            streetNumber = reader.GetInt32(2),
                            city = reader.GetString(3),
                            country = reader.GetString(4),
                            isDeleted = reader.GetBoolean(5)
                        };
                    }
                    return null;
                }
            }
        }

        public static int createNewAddress(Address newAddress)
        {
            using(SqlConnection connection = new SqlConnection(Util.CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"insert into Address (streetName, streetNumber, city, country)
                                        output inserted.id values (@streetName, @streetNumber, @city, @country)";

                command.Parameters.Add(new SqlParameter("streetName", newAddress.streetName));
                command.Parameters.Add(new SqlParameter("streetNumber", newAddress.streetNumber));
                command.Parameters.Add(new SqlParameter("city", newAddress.city));
                command.Parameters.Add(new SqlParameter("country", newAddress.country));

                return (int)command.ExecuteScalar();
            }
        }

        public static void editAddress(Address editedAddress)
        {
            using (SqlConnection connection = new SqlConnection(Util.CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"update Address set streetName = @streetName, streetNumber = @streetNumber, 
                                       city = @city, country = @country where id = @id";

                command.Parameters.Add(new SqlParameter("id", editedAddress.id));
                command.Parameters.Add(new SqlParameter("streetName", editedAddress.streetName));
                command.Parameters.Add(new SqlParameter("streetNumber", editedAddress.streetNumber));
                command.Parameters.Add(new SqlParameter("city", editedAddress.city));
                command.Parameters.Add(new SqlParameter("country", editedAddress.country));

                SqlDataReader reader = command.ExecuteReader();
            }
        }

    }
}
