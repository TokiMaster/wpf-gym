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
    /// Interaction logic for AddEditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        User modifyUser;
        public EditUserWindow(User user)
        {
            InitializeComponent();
            DataContext = user;
            modifyUser = user;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //User newUser = new User();
            //newUser.username = username.Text;
            //newUser.name = name.Text;
            //newUser.surname = name.Text;
            //newUser.gender = (Gender) gender.SelectedItem;
            //newUser.address.id = 10;
            //newUser.address.streetName = streetName.Text;
            //newUser.address.streetNumber = streetNumber.Text;
            //newUser.address.city = city.Text;
            //newUser.address.country = country.Text;
            //newUser.email = email.Text;
            //newUser.password = "";
            //UserCrudWindow.users.Add(newUser);
            this.Close();
        }

    }
}
