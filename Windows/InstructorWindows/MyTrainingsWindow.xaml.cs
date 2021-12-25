using System;
using SR23_2020_POP2021.Entities;
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

namespace SR23_2020_POP2021.Windows.InstructorWindows
{
    /// <summary>
    /// Interaction logic for MyTrainingsWindow.xaml
    /// </summary>
    public partial class MyTrainingsWindow : Window
    {
        public MyTrainingsWindow()
        {
            InitializeComponent();
            User banex = new User("Bane", "Branko", "Strbac", new Address(5, "Varga Djule", "35", "Novi Sad", "Srbija", false),
                Gender.MALE, "bane@gmail.com", "bane", Role.BEGINNER, true);
            User zoki = new User("Zoki", "Zoran", "Majovski", new Address(6, "Kosancic Ivana", "13", "Novi Sad", "Srbija", false),
                Gender.MALE, "zoki@gmail.com", "zoki", Role.INSTRUCTOR, false);
            Training training = new Training();
            training.id = 1;
            training.date = DateTime.Now;
            training.duration = new TimeSpan(0, 30, 0);
            training.instructor = zoki;
            training.beginner = banex;
            trainingsDG.Items.Add(training);

        }
    }
}
