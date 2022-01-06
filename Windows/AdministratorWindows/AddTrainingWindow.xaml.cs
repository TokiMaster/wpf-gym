﻿using SR23_2020_POP2021.Entities;
using SR23_2020_POP2021.Service;
using SR23_2020_POP2021.Servisi;
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
        List<Training> trainings;
        List<User> users;
        public AddTrainingWindow()
        {
            InitializeComponent();
            trainings = TrainingService.ReadTrainings();
            users = UserService.ReadUsers();
            status.ItemsSource = Enum.GetValues(typeof(Status)).Cast<Status>();

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
            this.Close();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}