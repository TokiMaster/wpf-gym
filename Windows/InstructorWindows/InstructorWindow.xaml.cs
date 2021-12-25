﻿using SR23_2020_POP2021.Entities;
using SR23_2020_POP2021.Windows.InstructorWindows;
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
    /// Interaction logic for InstructorWindow.xaml
    /// </summary>
    public partial class InstructorWindow : Window
    {
        User modifyUser;
        public InstructorWindow(User user)
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

        private void myTrainings_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MyTrainingsWindow myTrainingsWindow = new MyTrainingsWindow();
            myTrainingsWindow.Show();
            this.Close();
        }
    }
}