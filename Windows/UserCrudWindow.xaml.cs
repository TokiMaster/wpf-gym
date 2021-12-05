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

            User toki = new User("Toki", "Todor", "Popovic", new Address(1, "Seljackih buna", "93", "Novi Sad", "Srbija"),
                Gender.MALE, "toki@gmail.com", "toki", Role.ADMINISTRATOR, false);
            User vlaki = new User("Vlaki", "Vladica", "Jeremic", new Address(2, "Orlovica Pavla", "14", "Novi Sad", "Srbija"),
                Gender.FEMALE, "vlaki@gmail.com", "vlaki", Role.ADMINISTRATOR, false);
            User maki = new User("Maki", "Marija", "Jelaca", new Address(3, "Bate Brkica", "13", "Novi Sad", "Srbija"),
                Gender.FEMALE, "maki@gmail.com", "maki", Role.BEGGINER, false);
            User niki13 = new User("Niki", "Nikola", "Krstin", new Address(4, "Bulevar Vojvode Stepe", "46", "Novi Sad", "Srbija"),
                Gender.MALE, "niki13@gmail.com", "niki", Role.INSTRUCTOR, false);
            User banex = new User("Bane", "Branko", "Strbac", new Address(5, "Varga Djule", "35", "Novi Sad", "Srbija"),
                Gender.MALE, "bane@gmail.com", "bane", Role.BEGGINER, true);
            User zoki = new User("Zoki", "Zoran", "Majovski", new Address(6, "Kosancic Ivana", "13", "Novi Sad", "Srbija"),
                Gender.MALE, "zoki@gmail.com", "zoki", Role.INSTRUCTOR, false);

            users.Add(vlaki);
            users.Add(toki);
            users.Add(maki);
            users.Add(niki13);
            users.Add(banex);
            users.Add(zoki);

            for (int i = 0; i < users.Count(); i++)
            {
                User tempUser = users.ElementAt(i);
                if (!tempUser.isDeleted) { 
                    if (!tempUser.userRole.Equals(Role.ADMINISTRATOR))
                    {
                        UsersDG.Items.Add(tempUser);
                    }
                }
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            AdministratorWindow administratorWindow = new AdministratorWindow();
            administratorWindow.Show();
            this.Close();
        }

        private void addUser_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUser = new AddUserWindow();
            addUser.Show();
        }

        private void editUser_Click(object sender, RoutedEventArgs e)
        {
            User user = (User) UsersDG.SelectedItem;
            EditUserWindow editUser = new EditUserWindow(user);
            editUser.Show();
        }

        public void updateView()
        {
            UsersDG.Items.Filter = new Predicate<object>(view_Filter);
        }

        private bool view_Filter(object u)
        {
            User user = u as User;
            return !user.isDeleted;
        }

        private void deleteUser_Click(object sender, RoutedEventArgs e)
        {
            User deleteUser = (User)UsersDG.SelectedItem;
            if(MessageBox.Show("Are you sure you want to delete " + deleteUser.username,
                "Delete " + deleteUser.username, MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                deleteUser.isDeleted = true;
                updateView();
            }
            else
            {
                return;
            }
        }
    }
}
