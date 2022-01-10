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
    /// Interaction logic for EditTrainingWindow.xaml
    /// </summary>
    public partial class EditTrainingWindow : Window
    {
        List<Training> trainings;
        List<User> users;
        Training modifyTraining;

        public EditTrainingWindow(Training training)
        {
            InitializeComponent();
            DataContext = training;
            modifyTraining = training;
            trainings = TrainingService.ReadTrainings();
            users = UserService.ReadUsers();
            status.ItemsSource = Enum.GetValues(typeof(Status)).Cast<Status>();

            foreach(User user in users)
            {
                if (user.userRole.Equals(Role.INSTRUCTOR))
                {
                    instructorsCB.Items.Add(user);
                }
            }

            foreach (User user in users)
            {
                if (user.userRole.Equals(Role.BEGINNER))
                {
                    beginnersCB.Items.Add(user);
                }
            }

        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            TrainingService.editTraining(modifyTraining);
            this.Close();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
