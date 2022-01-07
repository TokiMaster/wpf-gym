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

        private void addUser_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUser = new AddUserWindow();
            addUser.Show();
            this.Close();
        }

        private void editUser_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = (User) UsersDG.SelectedItem;
            if (selectedUser == null)
            {
                MessageBox.Show("You didn't select any row", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                EditUserWindow editUser = new EditUserWindow(selectedUser);
                editUser.Show();
            }
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

        private bool searchFilter(object s)
        {
            User user = s as User;
            return user.username.Contains(value.Text) 
                 | user.name.Contains(value.Text) 
                 | user.surname.Contains(value.Text) 
                 | user.address.streetName.Contains(value.Text)
                 | user.address.city.Contains(value.Text)
                 | user.address.country.Contains(value.Text)
                 | user.email.Contains(value.Text) && !user.isDeleted;
        }

        private void deleteUser_Click(object sender, RoutedEventArgs e)
        {
            User deleteUser = (User)UsersDG.SelectedItem;
            if (deleteUser == null)
            {
                MessageBox.Show("You didn't select any row", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete " + deleteUser.username,
                    "Delete " + deleteUser.username, MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                {
                    UserService.deleteUser(deleteUser);
                    deleteUser.isDeleted = true;
                    updateView();
                }
            }
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            UsersDG.Items.Filter = new Predicate<object>(searchFilter);
        }
    }
}
