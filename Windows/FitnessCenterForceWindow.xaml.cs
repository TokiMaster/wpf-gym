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
    /// Interaction logic for FitnessCenterForceWindow.xaml
    /// </summary>
    public partial class FitnessCenterForceWindow : Window
    {

        List<User> users = new List<User>();
        FitnessCenter force = new FitnessCenter();

        public FitnessCenterForceWindow()
        {
            InitializeComponent();

            users = UserService.ReadUsers();
            force = FitnessCenterService.ReadFitnessCenter();

            foreach (User user in users)
            {
                if (user.userRole.Equals(Role.INSTRUCTOR))
                {
                    UsersDG.Items.Add(user);
                }
            }
            InfoDG.Items.Add(force); 
        }
    }
}
