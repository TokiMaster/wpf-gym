using SR23_2020_POP2021.Entities;
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
                Gender.FEMALE, "maki@gmail.com", "maki", Role.BEGINNER, false);
            User niki13 = new User("Niki", "Nikola", "Krstin", new Address(4, "Bulevar Vojvode Stepe", "46", "Novi Sad", "Srbija"),
                Gender.MALE, "niki13@gmail.com", "niki", Role.INSTRUCTOR, false);
            User banex = new User("Bane", "Branko", "Strbac", new Address(5, "Varga Djule", "35", "Novi Sad", "Srbija"),
                Gender.MALE, "bane@gmail.com", "bane", Role.BEGINNER, true);
            User zoki = new User("Zoki", "Zoran", "Majovski", new Address(6, "Kosancic Ivana", "13", "Novi Sad", "Srbija"),
                Gender.MALE, "zoki@gmail.com", "zoki", Role.INSTRUCTOR, false);

            users.Add(vlaki);
            users.Add(toki);
            users.Add(maki);
            users.Add(niki13);
            users.Add(banex);
            users.Add(zoki);
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
                        AdministratorWindow administratorWindow = new AdministratorWindow(tempUser);
                        administratorWindow.Show();
                        this.Close();
                    }
                    else if (tempUser.userRole.Equals(Role.INSTRUCTOR))
                    {
                        InstructorWindow instructorWindow = new InstructorWindow(tempUser);
                        instructorWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        BegginerWindow begginerWindow = new BegginerWindow(tempUser);
                        begginerWindow.Show();
                        this.Close();
                    }
                }
            }
        }
    }
}
