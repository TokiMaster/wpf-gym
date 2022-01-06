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
    /// Interaction logic for AllTrainingsWindow.xaml
    /// </summary>
    public partial class AllTrainingsWindow : Window
    {

        List<Training> trainings;

        public AllTrainingsWindow()
        {
            InitializeComponent();
            trainings = TrainingService.ReadTrainings();
            foreach (Training training in trainings)
            {
                trainingsDG.Items.Add(training);                
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

        private void addTraining_Click(object sender, RoutedEventArgs e)
        {
            AddTrainingWindow addTrainingWindow = new AddTrainingWindow();
            addTrainingWindow.Show();
        }

        private void editTraining_Click(object sender, RoutedEventArgs e)
        {
            Training selectedTraining = (Training)trainingsDG.SelectedItem;
            EditTrainingWindow editTrainingWindow = new EditTrainingWindow(selectedTraining);
            editTrainingWindow.Show();
        }

        private void deleteTraining_Click(object sender, RoutedEventArgs e)
        {
            Training deleteTraining = (Training)trainingsDG.SelectedItem;
            if (MessageBox.Show("Are you sure you want to delete training id = " + deleteTraining.id,
                "Delete " + deleteTraining.id, MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                TrainingService.deleteTrainingAdmin(deleteTraining);
                deleteTraining.isDeleted = true;
                updateView();
            }
        }
    }
}
