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

namespace SR23_2020_POP2021.Windows.BeginnerWindows
{
    /// <summary>
    /// Interaction logic for MyReservationsWindow.xaml
    /// </summary>
    public partial class MyReservationsWindow : Window
    {
        List<Training> trainings;
        public MyReservationsWindow(User user)
        {
            InitializeComponent();
            DataContext = user;
            trainings = TrainingService.ReadTrainings();
            foreach (Training training in trainings)
            {
                if(training.beginner != null)
                {
                    if (training.beginner.username.Equals(user.username) && training.status.Equals(Status.RESERVED))
                    {
                        trainingsDG.Items.Add(training);
                    }
                }
            }
        }

        public void updateView()
        {
            trainingsDG.Items.Filter = new Predicate<object>(view_Filter);
        }

        private bool view_Filter(object t)
        {
            Training training = t as Training;
            return !training.status.Equals(Status.FREE) && training.beginner!=null;
        }

        private void cancelReservation_Click(object sender, RoutedEventArgs e)
        {
            Training cancelTraining = (Training)trainingsDG.SelectedItem;

            if (cancelTraining == null)
            {
                MessageBox.Show("You didn't select any row", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to cancel training on " + cancelTraining.date.ToShortDateString() + 
                    " at " + cancelTraining.date.Hour + ":" + cancelTraining.date.Minute,
                    "Cancel training" , MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                {
                    TrainingService.cancelReservation(cancelTraining);
                    cancelTraining.status = Status.FREE;
                    cancelTraining.beginner = null;
                    updateView();
                }
            }
        }
    }
}
