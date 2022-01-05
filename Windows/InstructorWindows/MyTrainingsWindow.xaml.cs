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
        List<Training> trainings;
        
        public MyTrainingsWindow(User user)
        {
            InitializeComponent();
            DataContext = user;
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
            if(MessageBox.Show("Are you sure you want to delete training id = " + deleteTraining.id,
                "Delete " + deleteTraining.id, MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                TrainingService.deleteTraining(deleteTraining);
                deleteTraining.isDeleted = true;
                updateView();
            }
        }
    }
}
