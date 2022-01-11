using SR23_2020_POP2021.Entities;
using SR23_2020_POP2021.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
            gender.ItemsSource = Enum.GetValues(typeof(Gender)).Cast<Gender>();
            role.ItemsSource = Enum.GetValues(typeof(Role)).Cast<Role>();
        }

        
        private bool isValidEmail(string inputEmail)
        {
            string strRegex = @"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$";
            Regex regex = new Regex(strRegex);
            return regex.IsMatch(inputEmail);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (UserService.findUserByUsername(username.Text) != null)
            {
                MessageBox.Show("Username already taken", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (name.Text.Equals("")
              | surname.Text.Equals("")
              | gender.SelectedItem == null
              | streetName.Text.Equals("")
              | streetNumber.Text.Equals("")
              | city.Text.Equals("")
              | country.Text.Equals("")
              | email.Text.Equals("")
              | password.Text.Equals(""))
            {
                MessageBox.Show("You must fill all fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (isValidEmail(email.Text) != true)
            {
                MessageBox.Show("Invalid email address", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int streetNo = int.Parse(streetNumber.Text);

            Address newAddress = new Address
            {
                streetName = streetName.Text,
                streetNumber = streetNo,
                city = city.Text,
                country = country.Text
            };

            int id = AddressService.createNewAddress(newAddress);

            User newUser = new User
            {
                username = username.Text,
                name = name.Text,
                surname = surname.Text,
                gender = (Gender)gender.SelectedItem,
                address = AddressService.findOneByID(id),
                email = email.Text,
                password = password.Text,
                userRole = (Role) role.SelectedItem
            };

            UserService.createNewUser(newUser);
            UserCrudWindow userCrudWindow = new UserCrudWindow();
            userCrudWindow.Show();
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
