using SR23_2020_POP2021.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR23_2020_POP2021.Service
{
    public class FitnessCenterService
    {
        public static FitnessCenter ReadFitnessCenter()
        {
            using (SqlConnection connection = new SqlConnection(Util.CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"select * from FitnessCenter";

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return new FitnessCenter
                    {
                        id = reader.GetInt32(0),
                        name = reader.GetString(1),
                        address = AddressService.findOneByID(reader.GetInt32(2))
                    };
                }
                reader.Close();
            }
            return null;
        }
    }
}
