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
                if (training.beginner.username.Equals(user.username))
                {
                    trainingsDG.Items.Add(training);
                }
            }
        }
    }
}
