using System;
using SR23_2020_POP2021.Entities;
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
using SR23_2020_POP2021.Service;

namespace SR23_2020_POP2021.Windows.InstructorWindows
{
    /// <summary>
    /// Interaction logic for MyTrainingsWindow.xaml
    /// </summary>
    public partial class MyTrainingsWindow : Window
    {
        private List<Training> trainings;
        private User loggedInstructor;
        
        public MyTrainingsWindow(User user)
        {
            InitializeComponent();
            DataContext = user;
            loggedInstructor = user;
            trainings = TrainingService.ReadTrainings();
            foreach(Training training in trainings)
            {
                if (training.instructor.username.Equals(user.username))
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
            return !training.isDeleted;
        }


        private void deleteTraining_Click(object sender, RoutedEventArgs e)
        {
            Training deleteTraining = (Training)trainingsDG.SelectedItem;
            if (deleteTraining == null)
            {
                MessageBox.Show("You didn't select any row", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (deleteTraining.status.Equals(Status.FREE))
                {
                    if (MessageBox.Show("Are you sure you want to delete training on " + deleteTraining.date.ToShortDateString() +
                        " at " + deleteTraining.date.Hour + ":" + deleteTraining.date.Minute,
                        "Delete training", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                    {
                        TrainingService.deleteTraining(deleteTraining);
                        deleteTraining.isDeleted = true;
                        updateView();
                    }
                }
                else
                {
                    MessageBox.Show("You can't delete reserved training", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void addTraining_Click(object sender, RoutedEventArgs e)
        {
            AddTrainingWindow addTrainingWindow = new AddTrainingWindow(loggedInstructor);
            addTrainingWindow.Show();
            this.Close();
        }
    }
}
