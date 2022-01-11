using SR23_2020_POP2021.Entities;
using SR23_2020_POP2021.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SR23_2020_POP2021.Windows.InstructorWindows
{
    /// <summary>
    /// Interaction logic for AddTrainingWindow.xaml
    /// </summary>
    public partial class AddTrainingWindow : Window
    {
        private List<Training> trainings;
        private List<User> users;
        private User user;
        public AddTrainingWindow(User loggedInstructor)
        {
            InitializeComponent();
            DataContext = loggedInstructor;
            user = loggedInstructor;
            trainings = TrainingService.ReadTrainings();
            users = UserService.ReadUsers();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (date.SelectedDate == null
              | time.Text.Equals("")
              | duration.Text.Equals(""))
            {
                MessageBox.Show("You must fill all fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DateTime? dateTime = date.SelectedDate;
            TimeSpan timeOfDay = TimeSpan.Parse(time.Text);
            int duration1 = int.Parse(duration.Text);
            TimeSpan duration2 = TimeSpan.FromMinutes(duration1);
            
            Training newTraining = new Training
            {
                date = dateTime.Value.Add(timeOfDay),
                duration = duration2,
                status = Status.FREE,
                instructor = UserService.findUserByUsername(user.username),
                beginner = null
            };

            TrainingService.addTraining(newTraining);
            MyTrainingsWindow myTrainingsWindow = new MyTrainingsWindow(user);
            myTrainingsWindow.Show();
            this.Close();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            MyTrainingsWindow myTrainingsWindow = new MyTrainingsWindow(user);
            myTrainingsWindow.Show();
            this.Close();
        }
    }
}
