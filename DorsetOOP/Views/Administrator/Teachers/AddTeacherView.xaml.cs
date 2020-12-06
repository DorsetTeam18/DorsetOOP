/// Team 18
/// Student names | ID:
/// Wim POIGNON 23408
/// Maélis YONES 23217
/// Rémi LOMBARD 23210
/// Christophe NGUYEN 23219
/// Gwendoline MAREK 23397
/// Maxime DENNERY 23203
/// Victor TACHOIRES 22844

using DorsetOOP.Models;
using DorsetOOP.Models.Users;
using DorsetOOP.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace DorsetOOP
{
    public partial class AddTeacherView : Window, INotifyPropertyChanged
    {
        #region View Model
        public event PropertyChangedEventHandler PropertyChanged;

        private Teacher _teacherToAdd = new Teacher();
        public Teacher TeacherToAdd
        {
            get { return _teacherToAdd; }
            set
            {
                _teacherToAdd = value;
                PropertyChanged(this, new PropertyChangedEventArgs("TeacherToAdd"));
            }
        }

        private Address _addressToAdd = new Address();
        public Address AddressToAdd
        {
            get { return _addressToAdd; }
            set
            {
                _addressToAdd = value;
                PropertyChanged(this, new PropertyChangedEventArgs("AddressToAdd"));
            }
        }
        #endregion

        public AddTeacherView()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e) { this.Close(); }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (TeacherToAdd.FirstName == null || TeacherToAdd.LastName == "" ||
                TeacherToAdd.LastName == null || TeacherToAdd.LastName == "" ||
                TeacherToAdd.EmailAddress == null || TeacherToAdd.EmailAddress == "" ||
                TeacherToAdd.Password == null || TeacherToAdd.Password == "" ||
                TeacherToAdd.Gender == null ||
                AddressToAdd.AddressLine1 == null || AddressToAdd.AddressLine1 == "" ||
                AddressToAdd.City == null || AddressToAdd.City == "" ||
                AddressToAdd.Postcode == null || AddressToAdd.Postcode == "" ||
                AddressToAdd.Country == null || AddressToAdd.Country == "") MessageBox.Show("Please check your inputs!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                if (VirtualCollegeContext.CreateTeacher(TeacherToAdd, AddressToAdd))
                {
                    MessageBox.Show("Teacher created!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else MessageBox.Show("Couldn't create user", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
