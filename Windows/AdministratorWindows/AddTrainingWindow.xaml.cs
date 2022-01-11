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

namespace SR23_2020_POP2021.Windows.AdministratorWindows
{
    /// <summary>
    /// Interaction logic for AddTrainingWindow.xaml
    /// </summary>
    public partial class AddTrainingWindow : Window
    {
        private List<Training> trainings;
        private List<User> users;
        public AddTrainingWindow()
        {
            InitializeComponent();
            trainings = TrainingService.ReadTrainings();
            users = UserService.ReadUsers();
            statusCB.ItemsSource = Enum.GetValues(typeof(Status)).Cast<Status>();

            foreach (User user in users)
            {
                if (user.userRole.Equals(Role.INSTRUCTOR))
                {
                    instructorsCB.Items.Add(user.username);
                }
            }

            foreach (User user in users)
            {
                if (user.userRole.Equals(Role.BEGINNER))
                {
                    beginnersCB.Items.Add(user.username);
                }
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            AllTrainingsWindow allTrainingsWindow = new AllTrainingsWindow();
            allTrainingsWindow.Show();
            this.Close();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (date.SelectedDate == null
              | time.Text.Equals("")
              | duration.Text.Equals("")
              | statusCB.SelectedItem == null
              | instructorsCB.SelectedItem == null)
            {
                MessageBox.Show("You must fill all fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DateTime? dateTime = date.SelectedDate;
            TimeSpan timeOfDay = TimeSpan.Parse(time.Text);
            int duration1 = int.Parse(duration.Text);
            TimeSpan duration2 = TimeSpan.FromMinutes(duration1);
            User beginner = null; 
            if (beginnersCB.SelectedItem != null)
            {
                beginner = UserService.findUserByUsername(beginnersCB.SelectedItem.ToString());
            }

            Training newTraining = new Training
            {
                date = dateTime.Value.Add(timeOfDay),
                duration = duration2,
                status = (Status)statusCB.SelectedItem,
                instructor = UserService.findUserByUsername(instructorsCB.SelectedItem.ToString()),
                beginner = beginner
            };

            TrainingService.addTraining(newTraining);
            AllTrainingsWindow allTrainingsWindow = new AllTrainingsWindow();
            allTrainingsWindow.Show();
            this.Close();
        }
    }
}
