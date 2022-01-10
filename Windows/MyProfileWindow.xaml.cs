using SR23_2020_POP2021.Entities;
using SR23_2020_POP2021.Service;
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
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
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
