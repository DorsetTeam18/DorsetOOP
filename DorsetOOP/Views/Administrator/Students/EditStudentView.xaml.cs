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
using System.Collections.ObjectModel;
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
    public partial class EditStudentView : Window, INotifyPropertyChanged
    {
        #region View Models
        public event PropertyChangedEventHandler PropertyChanged;

        private Student _studentToEdit;
        public Student StudentToEdit
        {
            get { return _studentToEdit; }
            set
            {
                _studentToEdit = value;
                PropertyChanged(this, new PropertyChangedEventArgs("StudentToEdit"));
            }
        }

        private Address _addressToEdit = new Address();
        public Address AddressToEdit
        {
            get { return _addressToEdit; }
            set
            {
                _addressToEdit = value;
                PropertyChanged(this, new PropertyChangedEventArgs("AddressToEdit"));
            }
        }

        private ObservableCollection<Teacher> _teachers;
        public ObservableCollection<Teacher> Teachers
        {
            get { return _teachers; }
            set
            {
                _teachers = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Teachers"));
            }
        }
        #endregion

        public EditStudentView(Student _inputStudent)
        {
            
            InitializeComponent();
            StudentToEdit = _inputStudent;
            AddressToEdit = _inputStudent.Address;
            Teachers = new ObservableCollection<Teacher>(VirtualCollegeContext.GetAllTeachers());
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (VirtualCollegeContext.UpdateStudent(StudentToEdit, AddressToEdit))
            {
                MessageBox.Show("Student profile updated!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else MessageBox.Show("Couldn't update Student profile.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e) { this.Close(); }
    }
}
