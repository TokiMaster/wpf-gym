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
    /// Interaction logic for HomePageWindow.xaml
    /// </summary>
    public partial class HomePageWindow : Window
    {
        List<User> users = new List<User>();

        public HomePageWindow()
        {
            InitializeComponent();
            User toki = new User("Toki", "Todor", "Popovic", new Address(1, "Seljackih buna", 93, "Novi Sad", "Srbija"),
                Gender.MALE, "toki@gmail.com", "toki", Role.ADMINISTRATOR);
            User vlaki = new User("Vlaki", "Vladica", "Jeremic", new Address(2, "Orlovica Pavla", 14, "Novi Sad", "Srbija"),
                Gender.FEMALE, "vlaki@gmail.com", "vlaki", Role.INSTRUCTOR);
            User toki1 = new User("Toki", "Todor", "Popovic", new Address(1, "Seljackih buna", 93, "Novi Sad", "Srbija"),
                Gender.MALE, "toki@gmail.com", "toki", Role.ADMINISTRATOR);
            User vlaki1 = new User("Vlaki", "Vladica", "Jeremic", new Address(2, "Orlovica Pavla", 14, "Novi Sad", "Srbija"),
                Gender.FEMALE, "vlaki@gmail.com", "vlaki", Role.INSTRUCTOR);
            User toki2 = new User("Toki", "Todor", "Popovic", new Address(1, "Seljackih buna", 93, "Novi Sad", "Srbija"),
                Gender.MALE, "toki@gmail.com", "toki", Role.ADMINISTRATOR);
            User vlaki2 = new User("Vlaki", "Vladica", "Jeremic", new Address(2, "Orlovica Pavla", 14, "Novi Sad", "Srbija"),
                Gender.FEMALE, "vlaki@gmail.com", "vlaki", Role.INSTRUCTOR);

            users.Add(vlaki);
            users.Add(toki);
            users.Add(vlaki1);
            users.Add(toki1);
            users.Add(vlaki2);
            users.Add(toki2);

            for (int i = 0; i < users.Count(); i++)
            {
                User tempUser = users.ElementAt(i);
                UsersDG.Items.Add(tempUser);
                
            }

            //for (int i = 0; i < users.Count(); i++)
            //{
            //    User tempUser = users.ElementAt(i);
            //    if (tempUser.userRole.Equals(Role.INSTRUCTOR))
            //    {
            //        UsersDG.Items.Add(tempUser);
            //    }
            //}
        }

        private void signOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
