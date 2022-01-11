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
    /// Interaction logic for MyProfileWindow.xaml
    /// </summary>
    public partial class MyProfileWindow : Window
    {
        User modifyUser;
        public MyProfileWindow(User user)
        {
            InitializeComponent();
            DataContext = user;
            modifyUser = user;
            gender.ItemsSource = Enum.GetValues(typeof(Gender)).Cast<Gender>();
        }

        private bool isValidEmail(string inputEmail)
        {
            string strRegex = @"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$";
            Regex regex = new Regex(strRegex);
            return regex.IsMatch(inputEmail);
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
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

            AddressService.editAddress(modifyUser.address);
            UserService.editUser(modifyUser);
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
