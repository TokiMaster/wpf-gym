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
                    User user = null;

                    if (!reader.IsDBNull(5))
                    {
                        user = UserService.findUserByUsername(reader.GetString(5));
                    }

                    trainings.Add(new Training
                    {
                        id = reader.GetInt32(0),
                        date = reader.GetDateTime(1),
                        duration = TimeSpan.FromMinutes(reader.GetInt32(2)),
                        status = (Status) reader.GetInt32(3),
                        instructor = UserService.findUserByUsername(reader.GetString(4)),
                        beginner = user,
                        isDeleted = reader.GetBoolean(6)
                    });
                }
                reader.Close();
            }
            return trainings;
        }

        public static void reserveTraining(Training reserveTraining)
        {
            using (SqlConnection connection = new SqlConnection(Util.CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"update Trainings set status = 1, beginner = @beginner where id = @id";
                command.Parameters.Add(new SqlParameter("id", reserveTraining.id));
                command.Parameters.Add(new SqlParameter("beginner", reserveTraining.beginner.username));

                SqlDataReader reader = command.ExecuteReader();
            }
        }

        public static void cancelReservation(Training cancelTraining)
        {
            using (SqlConnection connection = new SqlConnection(Util.CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"update Trainings set status = 0, beginner = Null where id = @id";
                command.Parameters.Add(new SqlParameter("id", cancelTraining.id));

                SqlDataReader reader = command.ExecuteReader();
            }
        }

        public static void deleteTraining(Training deleteTraining)
        {
            using (SqlConnection connection = new SqlConnection(Util.CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"update Trainings set isDeleted = 1 where id = @id and status = 0";
                command.Parameters.Add(new SqlParameter("id", deleteTraining.id));
                command.Parameters.Add(new SqlParameter("status", deleteTraining.status));

                SqlDataReader reader = command.ExecuteReader();
            }
        }

        public static void deleteTrainingAdmin(Training deleteTraining)
        {
            using (SqlConnection connection = new SqlConnection(Util.CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"update Trainings set isDeleted = 1 where id = @id";
                command.Parameters.Add(new SqlParameter("id", deleteTraining.id));

                SqlDataReader reader = command.ExecuteReader();
            }
        }

        public static void addTraining(Training newTraining)
        {
            using (SqlConnection connection = new SqlConnection(Util.CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"insert into Trainings (startDate, duration, status, instructor, beginner)
                                        values (@startDate, @duration, @status, @instructor, @beginner)";
                command.Parameters.Add(new SqlParameter("startDate", newTraining.date));
                command.Parameters.Add(new SqlParameter("duration", newTraining.duration));
                command.Parameters.Add(new SqlParameter("status", newTraining.status));
                command.Parameters.Add(new SqlParameter("instructor", newTraining.instructor.username));
                command.Parameters.Add(new SqlParameter("beginner", newTraining.beginner.username));

                SqlDataReader reader = command.ExecuteReader();
            }
        }

        public static void editTraining(Training editTraining)
        {
            using (SqlConnection connection = new SqlConnection(Util.CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"update Trainings set startDate = @startDate, duration = @duration, 
                                        status = @status, instructor = @instructor, beginner = @beginner where id = @id";
                command.Parameters.Add(new SqlParameter("id", editTraining.id));
                command.Parameters.Add(new SqlParameter("startDate", editTraining.date));
                command.Parameters.Add(new SqlParameter("duration", editTraining.duration));
                command.Parameters.Add(new SqlParameter("status", editTraining.status));
                command.Parameters.Add(new SqlParameter("instructor", editTraining.instructor.username));
                command.Parameters.Add(new SqlParameter("beginner", editTraining.beginner.username));

                SqlDataReader reader = command.ExecuteReader();
            }
        }
    }
}
