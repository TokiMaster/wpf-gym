﻿using SR23_2020_POP2021.Entities;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        List<User> users = new List<User>();
        public LoginWindow()
        {
            InitializeComponent();
            User toki = new User("Toki", "Todor", "Popovic", new Address(1, "Seljackih buna", "93", "Novi Sad", "Srbija"),
                Gender.MALE, "toki@gmail.com", "toki", Role.ADMINISTRATOR, false);
            User vlaki = new User("Vlaki", "Vladica", "Jeremic", new Address(2, "Orlovica Pavla", "14", "Novi Sad", "Srbija"),
                Gender.FEMALE, "vlaki@gmail.com", "vlaki", Role.INSTRUCTOR, false);
            User maki = new User("Maki", "Marija", "Jelaca", new Address(3, "Bate Brkica", "13", "Novi Sad", "Srbija"),
               Gender.FEMALE, "maki@gmail.com", "maki", Role.BEGGINER, false);

            users.Add(vlaki);
            users.Add(toki);
            users.Add(maki);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow home = new MainWindow();
            home.Show();
            this.Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < users.Count(); i++)
            {
                User tempUser = users.ElementAt(i);
                if (tempUser.username.Equals(username.Text) && tempUser.password.Equals(password.Password.ToString()) && !tempUser.isDeleted)
                {
                    if (tempUser.userRole.Equals(Role.ADMINISTRATOR))
                    {
                        AdministratorWindow administratorWindow = new AdministratorWindow();
                        administratorWindow.Show();
                        this.Close();
                    } 
                    else if (tempUser.userRole.Equals(Role.INSTRUCTOR))
                    {
                        InstructorWindow instructorWindow = new InstructorWindow();
                        instructorWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        BegginerWindow begginerWindow = new BegginerWindow();
                        begginerWindow.Show();
                        this.Close();
                    }
                }
            }
        }
    }
}
