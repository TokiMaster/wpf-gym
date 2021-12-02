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
    /// Interaction logic for FitnessCenterForceWindow.xaml
    /// </summary>
    public partial class FitnessCenterForceWindow : Window
    {

        List<User> users = new List<User>();
        FitnessCenter force = new FitnessCenter();

        public FitnessCenterForceWindow()
        {
            InitializeComponent();
            User toki = new User("Toki", "Todor", "Popovic", new Address(1, "Seljackih buna", "93", "Novi Sad", "Srbija"),
                Gender.MALE, "toki@gmail.com", "toki", Role.ADMINISTRATOR, false);
            User vlaki = new User("Vlaki", "Vladica", "Jeremic", new Address(2, "Orlovica Pavla", "14", "Novi Sad", "Srbija"),
                Gender.FEMALE, "vlaki@gmail.com", "vlaki", Role.ADMINISTRATOR, false);
            User maki = new User("Maki", "Marija", "Jelaca", new Address(3, "Bate Brkica", "13", "Novi Sad", "Srbija"),
                Gender.FEMALE, "maki@gmail.com", "maki", Role.INSTRUCTOR, false);
            User niki13 = new User("Niki", "Nikola", "Krstin", new Address(4, "Bulevar Vojvode Stepe", "46", "Novi Sad", "Srbija"),
                Gender.MALE, "niki13@gmail.com", "niki", Role.INSTRUCTOR, false);
            User banex = new User("Bane", "Branko", "Strbac", new Address(5, "Varga Djule", "35", "Novi Sad", "Srbija"),
                Gender.MALE, "bane@gmail.com", "bane", Role.INSTRUCTOR, false);
            User zoki = new User("Zoki", "Zoran", "Majovski", new Address(6, "Kosancic Ivana", "13", "Novi Sad", "Srbija"),
                Gender.MALE, "zoki@gmail.com", "zoki", Role.INSTRUCTOR, false);
            force = new FitnessCenter(1, "The Force", new Address(7, "Bulevar Oslobodjenja", "85", "Novi Sad", "Srbija"));

            users.Add(vlaki);
            users.Add(toki);
            users.Add(maki);
            users.Add(niki13);
            users.Add(banex);
            users.Add(zoki);

            for (int i = 0; i < users.Count(); i++)
            {
                User tempUser = users.ElementAt(i);
                if (tempUser.userRole.Equals(Role.INSTRUCTOR))
                {
                    UsersDG.Items.Add(tempUser);
                }
            }

            InforDG.Items.Add(force);
        }
    }
}
