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

            using (SqlConnection conn = new SqlConnection(Util.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"select * from dbo.Address";

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    addresses.Add(new Address
                    {
                        id = reader.GetInt32(0),
                        streetName = reader.GetString(1),
                        streetNumber = reader.GetString(2),
                        city = reader.GetString(3),
                        country = reader.GetString(4),
                        isDeleted = reader.GetBoolean(5)
                    });
                }
                reader.Close();
            }
            return addresses;
        }

        public Address findOneByID(int id)
        {
            using (SqlConnection conn = new SqlConnection(Util.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"select * from dbo.Address where id = @id";
                command.Parameters.Add(new SqlParameter("id", id));
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Address
                    {
                        id = reader.GetInt32(0),
                        streetName = reader.GetString(1),
                        streetNumber = reader.GetString(2),
                        city = reader.GetString(3),
                        country = reader.GetString(4),
                        isDeleted = reader.GetBoolean(5)
                    };
                }
                return null;
            }
        }
    }
}
