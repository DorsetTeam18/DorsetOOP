using DorsetOOP.Models;
using DorsetOOP.Models.Users;
using DorsetOOP.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace DorsetOOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (var myDB = new VirtualCollegeContext())
            {
                var users = new List<User>();

                var firstAddress = new Address()
                {
                    AddressLine1 = "31 bvd Troussel",
                    AddressLine2 = "Bâtiment A, M08",
                    City = "Conflans",
                    Country = "France",
                    Postcode = "78700"
                };
                var secondAddress = new Address()
                {
                    AddressLine1 = "360 N Kenter",
                    City = "Los Angeles",
                    Country = "USA",
                    Postcode = "44400"
                };

                var s = new Student()
                {
                    FirstName = "Rémi",
                    LastName = "Lombard",
                    BirthDate = new DateTime(2000, 04, 17),
                    EmailAddress = "remi17.lombard@gmail.com",
                    Address = firstAddress,
                    Fees=10800
                };
                users.Add(s);

                var t = new Teacher() 
                {
                    FirstName = "Walter",
                    LastName = "Perreti",
                    BirthDate = new DateTime(1972, 01, 10),
                    EmailAddress = "w.p@edu.devinci.fr",
                    Address = secondAddress
                };
                users.Add(t);

                var a = new Administrator() 
                {
                    FirstName = "Bastien",
                    LastName = "Lombard",
                    BirthDate = new DateTime(2002, 04, 10),
                    EmailAddress = "bastien10.lombard@gmail.com",
                    Address = firstAddress
                };

                s.Tutor = t;

                users.Add(a);

                myDB.Users.AddRange(users);
                myDB.SaveChanges();
            }
        }

        private void button_1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello, World! :)", "First Window", MessageBoxButton.OK,MessageBoxImage.Information);   
        }
    }
}
