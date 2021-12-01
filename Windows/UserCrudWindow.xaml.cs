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
    /// Interaction logic for UserCrudWindow.xaml
    /// </summary>
    public partial class UserCrudWindow : Window
    {

        List<User> users = new List<User>();
        public UserCrudWindow()
        {

            InitializeComponent();

            User toki = new User("Toki", "Todor", "Popovic", new Address(1, "Seljackih buna", 93, "Novi Sad", "Srbija"),
                Gender.MALE, "toki@gmail.com", "toki", Role.ADMINISTRATOR);
            User vlaki = new User("Vlaki", "Vladica", "Jeremic", new Address(2, "Orlovica Pavla", 14, "Novi Sad", "Srbija"),
                Gender.FEMALE, "vlaki@gmail.com", "vlaki", Role.ADMINISTRATOR);
            User maki = new User("Maki", "Marija", "Jelaca", new Address(3, "Bate Brkica", 13, "Novi Sad", "Srbija"),
                Gender.MALE, "maki@gmail.com", "maki", Role.INSTRUCTOR);
            User niki13 = new User("Niki", "Nikola", "Krstin", new Address(4, "Bulevar Vojvode Stepe", 46, "Novi Sad", "Srbija"),
                Gender.FEMALE, "niki13@gmail.com", "niki", Role.INSTRUCTOR);
            User banex = new User("Bane", "Branko", "Strbac", new Address(5, "Varga Djule", 35, "Novi Sad", "Srbija"),
                Gender.MALE, "bane@gmail.com", "bane", Role.INSTRUCTOR);
            User zoki = new User("Zoki", "Zoran", "Majovski", new Address(6, "Kosancic Ivana", 13, "Novi Sad", "Srbija"),
                Gender.FEMALE, "zoki@gmail.com", "zoki", Role.INSTRUCTOR);

            users.Add(vlaki);
            users.Add(toki);
            users.Add(maki);
            users.Add(niki13);
            users.Add(banex);
            users.Add(zoki);

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
    }
}
