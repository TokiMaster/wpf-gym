using SR23_2020_POP2021.Entities;
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

namespace SR23_2020_POP2021.Windows
{
    /// <summary>
    /// Interaction logic for UserCrudWindow.xaml
    /// </summary>
    public partial class UserCrudWindow : Window
    {

        List<User> users;
        List<Address> addresses;

        public UserCrudWindow()
        {

            InitializeComponent();
            users = UserService.ReadUsers();
            addresses = AddressService.ReadAddresses();
            foreach (User user in users)
            {
                if (!user.isDeleted) {     
                    UsersDG.Items.Add(user);
                }
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            //AdministratorWindow administratorWindow = new AdministratorWindow();
            //administratorWindow.Show();
            //this.Close();
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
                UserService.deleteUser(deleteUser);
                updateView();
            }
            else
            {
                return;
            }
        }
    }
}
