using SR23_2020_POP2021.Entities;
using SR23_2020_POP2021.Windows.BeginnerWindows;
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

namespace SR23_2020_POP2021.Windows
{
    /// <summary>
    /// Interaction logic for BegginerWindow.xaml
    /// </summary>
    public partial class BegginerWindow : Window
    {
        User modifyUser;
        public BegginerWindow(User user)
        {
            InitializeComponent();
            DataContext = user;
            modifyUser = user;
        }

        private void signOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void myProfile_Click(object sender, RoutedEventArgs e)
        {
            MyProfileWindow myProfileWindow = new MyProfileWindow(modifyUser);
            myProfileWindow.Show();
        }


        private void reservation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MakeReservationWindow makeReservationWindow = new MakeReservationWindow();
            makeReservationWindow.Show();
        }

        private void myReservations_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MyReservationsWindow myReservationsWindow = new MyReservationsWindow(modifyUser);
            myReservationsWindow.Show();
        }
    }
}
