using SR23_2020_POP2021.Entities;
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
            foreach (User user in users)
            {
                if (user.username.Equals(username.Text) && user.password.Equals(password.Password.ToString()) && user.isDeleted.Equals(false))
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
            }
        }
    }
}
