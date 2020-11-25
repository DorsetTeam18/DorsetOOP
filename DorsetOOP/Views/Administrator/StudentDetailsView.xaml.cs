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
    /// Interaction logic for StudentDetailsView.xaml
    /// </summary>
    public partial class StudentDetailsView : Window, INotifyPropertyChanged
    {
        #region ViewModel
        private Student _test = new Student();
        public Student Test
        {
            get { return _test; }
            set
            {
                _test = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Test"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        public StudentDetailsView(Student _student)
        {
            InitializeComponent();
            Test = _student;
        }        
    }
}
