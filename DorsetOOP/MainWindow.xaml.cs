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
	/// Name of the Students :
	/// Wim Poignon 23408
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            displayGrades.Text = "";

            using (var myDB = new VirtualCollegeContext())
            {
                var addresses = myDB.Addresses.ToList();

                var studs = myDB.Users.OfType<Student>().ToList();
                var teachers = myDB.Users.OfType<Teacher>().ToList();
                var courses = myDB.Courses.ToList();
                var lessons = myDB.Lessons.ToList();

                #region Students
                //var premierEleve = new Student()
                //{
                //    FirstName = "Maxime",
                //    LastName = "Dennery",
                //    Gender = "Male",
                //    BirthDate = new DateTime(2000, 3, 6),
                //    Address = addresses.Find(a => a.AddressId == 1),
                //    EmailAddress = "maxime.dennery@edu.devinci.fr",
                //    Fees = 10800,
                //    Password = "LOLMDRXD"
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
                //    Fees = 10800,
                //    Password = "ELABORE"
                //};
                //studs.Add(secondEleve);
                //var troisisemeEleve = new Student()
                //{
                //    FirstName = "Gwen",
                //    LastName = "Marek",
                //    Gender = "Female",
                //    BirthDate = new DateTime(2005, 1, 5),
                //    Address = addresses.Find(a => a.AddressId == 3),
                //    EmailAddress = "gwen.marek@edu.devinci.fr",
                //    Fees = 10800,
                //    Password = "maquillage"
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
                //var firstProf = new Teacher()
                //{
                //    FirstName = "Walter",
                //    LastName = "perreti",
                //    Gender = "Male",
                //    BirthDate = new DateTime(1972, 01, 10),
                //    Address = addresses.Find(a => a.AddressId == 2),
                //    EmailAddress = "w.p@edu.devinci.fr",
                //    Password = "MECATRONIQUE"
                //};
                //teachers.Add(firstProf);
                //var secondPorf = new Teacher()
                //{
                //    FirstName = "Olivier",
                //    LastName = "Zanette",
                //    Gender = "Male",
                //    BirthDate = new DateTime(1977, 01, 10),
                //    Address = addresses.Find(a => a.AddressId == 3),
                //    EmailAddress = "o.z@edu.devinci.fr",
                //    Password = "ELEC"
                //};
                //teachers.Add(secondPorf);
                //var terreur = new Teacher()
                //{
                //    FirstName = "Noémie",
                //    LastName = "Thaï",
                //    Gender = "Female",
                //    BirthDate = new DateTime(1988, 7, 14),
                //    Address = addresses.Find(a => a.AddressId == 5),
                //    EmailAddress = "n.t@edu.devinci.fr",
                //    Password = "THERMO"
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
                //    EmailAddress = "p.b@edu.devinci.fr",
                //    Password = "JE SUIS LE CHEF"
                //};
                //myDB.Users.Add(superAdmin);
                #endregion

                #region Courses
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
                //var firstLesson = new Lesson()
                //{
                //    Course = courses.FirstOrDefault(c => c.Title == "Electricity"),
                //    Day = "Tuesday",
                //    Hour = "08:15",
                //    Duration = "03:00",
                //    RoomName = "L309",
                //    Teacher = courses.FirstOrDefault(c => c.Title == "Electricity").Teachers.FirstOrDefault(t => t.LastName == "Zanette")
                //};

                //firstLesson.Students.Add(studs.FirstOrDefault(s => s.FirstName == "Gwen"));

                //firstLesson.EnrollStudent(studs.FirstOrDefault(s=>s.FirstName=="Christophe")); // Enrolls l'élève qui s'appelle Christophe

                //foreach (var s in studs.FindAll(s => s.Address == addresses.Find(a => a.Country == "Colombia"))) myDB.Lessons.FirstOrDefault(l => l.Day == "Tuesday").Students.Add(s);
                //myDB.Lessons.Add(firstLesson);

                #endregion

                #region Grades

                var grades = new List<Grade>();

                var firstGrade = new Grade()
                {
                    Course = courses.Find(c => c.Title == "Mathematics"),
                    Coefficient = 1,
                    ExamName = "CC1",
                    Mark = 60,
                    Student = myDB.Users.OfType<Student>().FirstOrDefault(s => s.FirstName == "Rémi")
                };
                grades.Add(firstGrade);

                var secondGrade = new Grade()
                {
                    Course = courses.Find(c => c.Title == "Mecatronnics"),
                    Coefficient = 2,
                    ExamName = "Online quizz #1",
                    Mark = 92.75m,
                    Student = myDB.Users.OfType<Student>().FirstOrDefault(s => s.FirstName == "Christophe")
                };
                grades.Add(secondGrade);

                var thirdGrade = new Grade()
                {
                    Course = courses.Find(c => c.Title == "Mecatronnics"),
                    Coefficient = 2,
                    ExamName = "Online quizz #1",
                    Mark = 12.25m,
                    Student = myDB.Users.OfType<Student>().FirstOrDefault(s => s.FirstName == "Maxime")
                };
                grades.Add(thirdGrade);

                myDB.Grades.AddRange(grades);

                #endregion

                myDB.SaveChanges();

                var u = myDB.Users.OfType<Student>().ToList().FindAll(s=>s.Grades.Count!=0);
                foreach (var p in u)
                {
                    displayGrades.Text += p.GradesInfo + "\n\n"; 
                }

                //foreach (var s in myDB.Users.OfType<Student>().ToList().FindAll(s => s.Grades != null)) displayGrades.Text += s.GradesInfo;                
            }
        }
    }
}
