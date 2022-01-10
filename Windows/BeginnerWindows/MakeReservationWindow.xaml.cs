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
    /// Interaction logic for MakeReservationWindow.xaml
    /// </summary>
    public partial class MakeReservationWindow : Window
    {

        List<Training> trainings;
        User user1;

        public MakeReservationWindow(User user)
        {
            InitializeComponent();
            DataContext = user;
            user1 = user;
            trainings = TrainingService.ReadTrainings();
            foreach (Training training in trainings)
            {
                if (training.status.Equals(Status.FREE))
                {
                    trainingsDG.Items.Add(training);
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
            return !training.status.Equals(Status.RESERVED) && training.beginner == null;
        }

        private void Reserve_Click(object sender, RoutedEventArgs e)
        {
            Training reserveTraining = (Training)trainingsDG.SelectedItem;
            if (reserveTraining == null)
            {
                MessageBox.Show("You didn't select any row", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to make reservation on " + reserveTraining.date.ToShortDateString() +
                    " at " + reserveTraining.date.Hour + ":" + reserveTraining.date.Minute,
                    "Make reservation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                {
                    reserveTraining.beginner = user1;
                    TrainingService.reserveTraining(reserveTraining);
                    reserveTraining.status = Status.RESERVED;
                    updateView();
                }
            }
        }
    }
}
