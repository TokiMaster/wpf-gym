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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            gender.ItemsSource = Enum.GetValues(typeof(Gender)).Cast<Gender>();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
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
                gender = (Gender) gender.SelectedItem,
                address = AddressService.findOneByID(id),
                email = email.Text,
                password = password.Text,
                userRole = Role.BEGINNER
            };

            UserService.createNewUser(newUser);

            BegginerWindow begginerWindow = new BegginerWindow(newUser);
            begginerWindow.Show();
            this.Close();

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow home = new MainWindow();
            home.Show();
            this.Close();
        }
    }
}
