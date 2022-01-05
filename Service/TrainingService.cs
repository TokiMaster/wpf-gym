using SR23_2020_POP2021.Entities;
using SR23_2020_POP2021.Servisi;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR23_2020_POP2021.Service
{
    public class TrainingService
    {
        public static List<Training> ReadTrainings()
        {
            List<Training> trainings = new List<Training>();

            using (SqlConnection connection = new SqlConnection(Util.CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"select * from Trainings where isDeleted = 0";

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    trainings.Add(new Training
                    {
                        id = reader.GetInt32(0),
                        date = reader.GetDateTime(1),
                        duration = TimeSpan.FromMinutes(reader.GetInt32(2)),
                        status = (Status) reader.GetInt32(3),
                        instructor = UserService.findUserByUsername(reader.GetString(4)),
                        beginner = UserService.findUserByUsername(reader.GetString(5)),
                        isDeleted = reader.GetBoolean(6)
                    });
                }
                reader.Close();
            }
            return trainings;
        }
    }
}
