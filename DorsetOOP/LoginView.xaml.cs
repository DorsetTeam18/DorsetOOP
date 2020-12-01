using DorsetOOP.Models;
using DorsetOOP.Models.Users;
using DorsetOOP.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public User LoggedUser { get; set; }

        public LoginView()
        {
            InitializeComponent();
            userLoginInput.Focus();

            using (var myDB = new VirtualCollegeContext())
            {
                #region Get Tables
                var addresses = myDB.Addresses.ToList();

                var studs = myDB.Users.
                    Include("Lessons").
                    OfType<Student>().
                    ToList();

                var teachers = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().ToList();

                var courses = myDB.Courses.
                    Include("Teachers").
                    ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();
                #endregion

                #region Initial inputs
                #region Students
                //myDB.Addresses.Add(new Address()
                //{
                //    AddressLine1 = "31 bvd Troussel",
                //    AddressLine2 = "Building A, M08",
                //    City = "Conflans",
                //    State = "Yvelines",
                //    Postcode = "78700",
                //    Country = "France"
                //});

                //var studs = new List<Student>();
                //var premierEleve = new Student()
                //{
                //    FirstName = "Maxime",
                //    LastName = "Dennery",
                //    Gender = "Male",
                //    BirthDate = new DateTime(2000, 3, 6),
                //    Address = addresses.Find(a => a.AddressId == 1),
                //    EmailAddress = "2",
                //    Fees = 10800,
                //    Password = "2"
                //};
                //studs.Add(premierEleve);

                //var secondEleve = new Student()
                //{
                //    FirstName = "Christophe",
                //    LastName = "Nguyen",
                //    Gender = "Male",
                //    BirthDate = new DateTime(2000, 12, 10),
                //    Address = addresses.Find(a => a.AddressId == 6),
                //    EmailAddress = "chri.ngu@edu.devinci.fr",
                //    Fees = 7600,
                //    Password = "chocolate123"
                //};
                //studs.Add(secondEleve);

                //var troisisemeEleve = new Student()
                //{
                //    FirstName = "Gwendoline",
                //    LastName = "Marek",
                //    Gender = "Female",
                //    BirthDate = new DateTime(2000, 1, 5),
                //    Address = addresses.Find(a => a.AddressId == 3),
                //    EmailAddress = "gwen.marek@edu.devinci.fr",
                //    Fees = 12500,
                //    Password = "ABC123"
                //};
                //studs.Add(troisisemeEleve);

                //var quatriemeEleve = new Student()
                //{
                //    FirstName = "Rémi",
                //    LastName = "Lombard",
                //    Gender = "Male",
                //    BirthDate = new DateTime(2000, 4, 17),
                //    Address = addresses.Find(a => a.AddressId == 1),
                //    EmailAddress = "remi.lombard@edu.devinci.fr",
                //    Fees = 10800,
                //    Password = "@@"
                //};
                //studs.Add(quatriemeEleve);

                //myDB.Users.AddRange(studs);
                #endregion

                #region Teachers
                //var teachers = new List<Teacher>();
                //var firstProf = new Teacher()
                //{
                //    FirstName = "Walter",
                //    LastName = "Perreti",
                //    Gender = "Male",
                //    BirthDate = new DateTime(1972, 01, 10),
                //    Address = addresses.Find(a => a.AddressId == 2),
                //    EmailAddress = "w.p@edu.devinci.fr",
                //    Password = "MathForLife"
                //};
                //teachers.Add(firstProf);

                //var secondProf = new Teacher()
                //{
                //    FirstName = "Olivier",
                //    LastName = "Zanette",
                //    Gender = "Male",
                //    BirthDate = new DateTime(1977, 01, 10),
                //    Address = addresses.Find(a => a.AddressId == 3),
                //    EmailAddress = "o.z@edu.devinci.fr",
                //    Password = "ILoveElectricity<3"
                //};
                //teachers.Add(secondProf);

                //var terreur = new Teacher()
                //{
                //    FirstName = "Marie-Noémie",
                //    LastName = "Thaï",
                //    Gender = "Female",
                //    BirthDate = new DateTime(1988, 7, 14),
                //    Address = addresses.Find(a => a.AddressId == 5),
                //    EmailAddress = "n.t@edu.devinci.fr",
                //    Password = "ComplexPassword@!123"
                //};
                //teachers.Add(terreur);

                //myDB.Users.AddRange(teachers);
                #endregion

                #region Admins
                //var superAdmin = new Administrator()
                //{
                //    FirstName = "Pascal",
                //    LastName = "Brouaye",
                //    Gender = "Male",
                //    BirthDate = new DateTime(1972, 01, 10),
                //    Address = addresses.Find(a => a.AddressId == 6),
                //    EmailAddress = "1",
                //    Password = "1"
                //};
                //myDB.Users.Add(superAdmin);
                #endregion

                #region Courses
                //var courses = new List<Course>();
                //var maths = new Course()
                //{
                //    Title = "Mathematics",
                //    Credits = 30,
                //    ReferentTeacher = teachers.FirstOrDefault(t => t.LastName == "Thaï")
                //};
                //courses.Add(maths);

                //var meca = new Course()
                //{
                //    Title = "Mecatronnics",
                //    Credits = 15,
                //    ReferentTeacher = teachers.FirstOrDefault(t => t.LastName.Contains("reti"))
                //};
                //courses.Add(meca);

                //var elec = new Course()
                //{
                //    Title = "Electricity",
                //    Credits = 30,
                //    ReferentTeacher = teachers.FirstOrDefault(t => t.LastName == "Zanette")
                //};
                //courses.Add(elec);

                //courses.Find(c => c.Title == "Mecatronnics").Teachers = new List<Teacher>() { teachers.Find(t => t.LastName == "Zanette" || t.LastName.Contains("rreti")) };
                //courses.Find(c => c.Title == "Electricity").Teachers = new List<Teacher>() { teachers.Find(t => t.LastName == "Zanette" || t.LastName.Contains("rreti")) };
                //courses.Find(c => c.Title == "Mathematics").Teachers = new List<Teacher>() { teachers.Find(t => t.LastName == "Thaï") };

                //myDB.Courses.AddRange(courses);
                #endregion

                #region Lessons
                //var lessons = new List<Lesson>();
                //var firstLesson = new Lesson()
                //{
                //    Course = courses.FirstOrDefault(c => c.Title == "Electricity"),
                //    Day = "Tuesday",
                //    Hour = "08:15",
                //    Duration = "03:00",
                //    RoomName = "L309",
                //    Teacher = courses.FirstOrDefault(c => c.Title == "Electricity").Teachers.FirstOrDefault(t => t.LastName == "Zanette")
                //};
                //lessons.Add(firstLesson);

                //var secondLesson = new Lesson()
                //{
                //    Course = courses.FirstOrDefault(c => c.Title.Contains("Math")),
                //    Day = "Friday",
                //    Hour = "16:30",
                //    Duration = "02:30",
                //    RoomName = "E256",
                //    Teacher = courses.FirstOrDefault(c => c.Title.Contains("Math")).Teachers.FirstOrDefault(t => t.LastName == "Thaï")
                //};
                //lessons.Add(secondLesson);

                //myDB.Lessons.AddRange(lessons);

                //myDB.SaveChanges();

                //lessons.Find(l => l.LessonId == 1).Teacher = teachers.Find(c => c.LastName == "Zanette");

                //var a = studs.FindAll(s => s.UserId == 2 || s.UserId == 3);
                //foreach (var s in a)
                //{
                //    lessons.Find(l => l.LessonId == 1).Students.Add(s);
                //}


                //a = studs.FindAll(s => s.FirstName == "Christophe" || s.LastName == "Dennery" || s.UserId == 1);

                //foreach (var s in a)
                //{
                //    lessons.Find(l => l.LessonId == 2).Students.Add(s);
                //}
                #endregion

                #region Grades
                //var grades = new List<Grade>();

                //var firstGrade = new Grade()
                //{
                //    Course = courses.Find(c => c.Title == "Mathematics"),
                //    Coefficient = 1,
                //    ExamName = "Test 1",
                //    Mark = 60,
                //    Student = myDB.Users.OfType<Student>().FirstOrDefault(s => s.FirstName == "Rémi")
                //};
                //grades.Add(firstGrade);

                //var secondGrade = new Grade()
                //{
                //    Course = courses.Find(c => c.Title == "Mecatronnics"),
                //    Coefficient = 2,
                //    ExamName = "Online quizz #1",
                //    Mark = 92.75m,
                //    Student = myDB.Users.OfType<Student>().FirstOrDefault(s => s.FirstName == "Christophe")
                //};
                //grades.Add(secondGrade);

                //var thirdGrade = new Grade()
                //{
                //    Course = courses.Find(c => c.Title == "Mecatronnics"),
                //    Coefficient = 2,
                //    ExamName = "Online quizz #1",
                //    Mark = 12.25m,
                //    Student = myDB.Users.OfType<Student>().FirstOrDefault(s => s.FirstName == "Maxime")
                //};
                //grades.Add(thirdGrade);

                //var fourthGrade = new Grade()
                //{
                //    Course = courses.Find(c => c.Title == "Mecatronnics"),
                //    Coefficient = 2,
                //    ExamName = "Online quizz #2",
                //    Mark = 64,
                //    Student = myDB.Users.OfType<Student>().FirstOrDefault(s => s.FirstName == "Maxime")
                //};
                //grades.Add(fourthGrade);

                //myDB.Grades.AddRange(grades);

                //myDB.Grades.Add(new Grade()
                //{
                //    Course = courses.Find(c => c.CourseId == 2),
                //    ExamName = "Test Exam to delete",
                //    Mark = 52,
                //    Coefficient = 3,
                //    Student = studs.Find(s => s.UserId == 1)
                //});
                #endregion

                #region Course Test
                //List<Teacher> teachersThatCanTeach = new List<Teacher>()
                //{
                //    teachers.Find(x => x.FirstName == "Marie-Noémie"),
                //    teachers.Find(x => x.FirstName == "Walter")
                //};

                //Course newCourse = new Course()
                //{
                //    Title = "Espaces Vect",
                //    Credits = 5,
                //    ReferentTeacher = teachers.Find(x => x.FirstName == "Marie-Noémie")
                //};

                //foreach (Teacher item in teachersThatCanTeach)
                //{
                //    newCourse.Teachers.Add(item);
                //}

                //myDB.Courses.Add(newCourse);
                #endregion
                #endregion

                var t = studs.Find(s => s.FirstName == "Maxime");
                t.AddPayment(DateTime.Now, 1000);

                myDB.SaveChanges();
            }
        }

        private void UserLoginButton_Click(object sender, RoutedEventArgs e)
        {
            User a = new Administrator();
            using(var myDb = new VirtualCollegeContext())
            {
                var addresses = myDb.Addresses.ToList();

                var payments = myDb.Payments.ToList();

                var lessons = myDb.Lessons.Include("Students").ToList();

                var courses = myDb.Courses.Include("Teachers").ToList();

                var grades = myDb.Grades.ToList();

                a = myDb.Users.ToList().Find(u => u.EmailAddress == userLoginInput.Text && u.Password == userPasswordinput.Password.ToString());
            }

            if (a != null)
            {
                var t = a.GetType().Name.Split('_')[0];
                switch (t)
                {
                    case "Student":
                        StudentView studentViewWindow = new StudentView(a);
                        studentViewWindow.Closing += new CancelEventHandler(AnyViewWindow_Closing);
                        studentViewWindow.Show();
                        this.Visibility = Visibility.Hidden;
                        break;

                    case "Teacher":
                        TeacherView teacherViewWindow = new TeacherView(a);
                        teacherViewWindow.Closing += new CancelEventHandler(AnyViewWindow_Closing);
                        teacherViewWindow.Show();
                        this.Visibility = Visibility.Hidden;
                        break;

                    case "Administrator":
                        AdministratorView adminViewWindow = new AdministratorView(a);
                        adminViewWindow.Closing += new CancelEventHandler(AnyViewWindow_Closing);
                        adminViewWindow.Show();
                        this.Visibility = Visibility.Hidden;
                        break;
                    default:
                        break;
                }
            }
            else MessageBox.Show($"Wrong login and/or password!", "Wrong login", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void AnyViewWindow_Closing(object sender, CancelEventArgs e) { this.Visibility = Visibility.Visible; }

        private void Input_KeyDown(object sender, KeyEventArgs e) { if (e.Key == Key.Enter) UserLoginButton_Click(new object(), new RoutedEventArgs()); }
    }
}
