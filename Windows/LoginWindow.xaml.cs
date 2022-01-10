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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        List<User> users = new List<User>();
        public LoginWindow()
        {
            InitializeComponent();
            users = UserService.ReadUsers();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow home = new MainWindow();
            home.Show();
            this.Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {

            String usernameTXT = username.Text;
            String passwordTXT = password.Password.ToString();

            User user = UserService.login(usernameTXT, passwordTXT);

            if(user != null)
            {
                if (user.userRole.Equals(Role.ADMINISTRATOR))
                {
                    AdministratorWindow administratorWindow = new AdministratorWindow(user);
                    administratorWindow.Show();
                    this.Close();
                }
                else if (user.userRole.Equals(Role.INSTRUCTOR))
                {
                    InstructorWindow instructorWindow = new InstructorWindow(user);
                    instructorWindow.Show();
                    this.Close();
                }
                else
                {
                    BegginerWindow begginerWindow = new BegginerWindow(user);
                    begginerWindow.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Username or password incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
