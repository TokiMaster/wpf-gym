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
    /// Interaction logic for AddEditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        User modifyUser;
        public EditUserWindow(User user)
        {
            InitializeComponent();
            gender.ItemsSource = Enum.GetValues(typeof(Gender)).Cast<Gender>();
            role.ItemsSource = Enum.GetValues(typeof(Role)).Cast<Role>();
            DataContext = user;
            modifyUser = user;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            AddressService.editAddress(modifyUser.address);
            UserService.editUser(modifyUser);
            this.Close();
        }

    }
}
