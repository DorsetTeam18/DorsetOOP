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
    /// Interaction logic for TeacherDetailsView.xaml
    /// </summary>
    public partial class TeacherDetailsView : Window, INotifyPropertyChanged
    {

        #region ViewModel
        public event PropertyChangedEventHandler PropertyChanged;

        private Teacher _selectedTeacher = new Teacher();
        public Teacher SelectedTeacher
        {
            get { return _selectedTeacher; }
            set
            {
                _selectedTeacher = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedTeacher"));
            }
        }
        #endregion

        public TeacherDetailsView(Teacher _inputTeacher)
        {
            InitializeComponent();
            SelectedTeacher = _inputTeacher;
        }
    }
}