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
    /// Interaction logic for EditLessonView.xaml
    /// </summary>
    public partial class EditLessonView : Window, INotifyPropertyChanged
    {
        #region View Models
        public event PropertyChangedEventHandler PropertyChanged;

        private Lesson _lessonToEdit;
        public Lesson LessonToEdit
        {
            get { return _lessonToEdit; }
            set
            {
                _lessonToEdit = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LessonToEdit"));
            }
        }


        #endregion

        public EditLessonView(Lesson _inputLesson)
        {
            InitializeComponent();
            LessonToEdit = _inputLesson;
        }

        private void CloseLessonButton_Click(object sender, RoutedEventArgs e) { this.Close(); }
    }
}
