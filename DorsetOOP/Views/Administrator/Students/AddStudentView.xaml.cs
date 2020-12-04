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
    /// <summary>
    /// Interaction logic for AddStudentView.xaml
	/// Name of the Students :
	/// Wim Poignon 23408
    /// </summary>
    public partial class AddStudentView : Window, INotifyPropertyChanged
    {
        #region ViewModel
        public event PropertyChangedEventHandler PropertyChanged;

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

        private Student _studentToAdd = new Student();
        public Student StudentToAdd
        {
            get { return _studentToAdd; }
            set
            {
                _studentToAdd = value;
                PropertyChanged(this, new PropertyChangedEventArgs("StudentToAdd"));
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

        public AddStudentView()
        {
            InitializeComponent();
            Teachers = new ObservableCollection<Teacher>(VirtualCollegeContext.GetAllTeachers());
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e) { this.Close(); }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (VirtualCollegeContext.CreateStudent(StudentToAdd, AddressToAdd))
            {
                MessageBox.Show("Student created!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else MessageBox.Show("Couldn't create user", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
