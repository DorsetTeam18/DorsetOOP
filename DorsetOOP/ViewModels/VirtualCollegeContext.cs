// Team 18
// Student names | ID:
// Wim POIGNON | 23408
// Maélis YONES | 23217
// Rémi LOMBARD | 23210
// Christophe NGUYEN | 23219
// Gwendoline MAREK | 23397
// Maxime DENNERY | 23203
// Victor TACHOIRES | 22844

using DorsetOOP.Models;
using DorsetOOP.Models.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DorsetOOP.ViewModels
{
    /// Interaction with the Database named VirtualCollege
    public class VirtualCollegeContext : DbContext // Inheritance from DbContext (included in EF)
    {
        public VirtualCollegeContext() : base("name=VirtualCollege") { } // Connection string

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); // Remove the basic ManyToMany definitions


            // Set up ManyToMany manually

            // Students - Lessons
            modelBuilder.Entity<Lesson>().
                HasMany(c => c.Students).
                WithMany(p => p.Lessons).
                Map(
                m =>
                    {
                        m.MapLeftKey("LessonId");
                        m.MapRightKey("UserId");
                        m.ToTable("StudentLessons");
                    });

            // Present Students - Lessons
            modelBuilder.Entity<Lesson>().
                HasMany(c => c.PresentStudents).
                WithMany(p => p.PresentLessons).
                Map(
                m =>
                {
                    m.MapLeftKey("LessonId");
                    m.MapRightKey("UserId");
                    m.ToTable("PresentStudentLessons");
                });

            // Teachers - Courses
            modelBuilder.Entity<Course>().
                Ignore(x => x.ParticipatingStudents).
                Ignore(x => x.AllCourseGrades).
                HasMany(c => c.Teachers).
                WithMany(p => p.Courses).
                Map(
                m =>
                    {
                        m.MapLeftKey("CourseId");
                        m.MapRightKey("UserId");
                        m.ToTable("TeacherCourses");
                    });
        }

        #region Tables of the database (set a virtual to enable lazy loading)
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        #endregion

        #region Static Methods (by convention, this is where the program interacts with the database. We could have made a separate class library for data access) 
        #region Get all elements - methods that return a List<T> of all the elements requested from the DB
        // The challenge here is to make sure we return entities that have the link to the rest of the information stored in the DB (addresses, grades, etc.)

        public static List<Student> GetAllStudents() // Returns a List<Student> representing all the students in the DB
        {
            var toReturn = new List<Student>();
            using (var myDB = new VirtualCollegeContext())
            {
                var addresses = myDB.Addresses.ToList();

                var courses = myDB.Courses.
                    Include("Teachers").
                    ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    Include("PresentStudents").
                    ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                var teachers = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();

                toReturn = myDB.Users.
                    Include("Lessons").
                    Include("PresentLessons").
                    OfType<Student>().
                    ToList();
            }
            return toReturn;
        }

        public static List<Teacher> GetAllTeachers() // Returns a List<Teacher> representing all the students in the DB
        {
            var toReturn = new List<Teacher>();
            using (var myDB = new VirtualCollegeContext())
            {
                var addresses = myDB.Addresses.ToList();

                var courses = myDB.Courses.
                    Include("Teachers").
                    ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    Include("PresentStudents").
                    ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                var students = myDB.Users.
                    Include("Lessons").
                    Include("PresentLessons").
                    OfType<Student>().
                    ToList();

                toReturn = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();
            }
            return toReturn;
        }

        public static List<Course> GetAllCourses() // Returns a List<Course> representing all the courses in the DB
        {
            var toReturn = new List<Course>();
            using (var myDB = new VirtualCollegeContext())
            {
                var students = myDB.Users.
                    Include("Lessons").
                    Include("PresentLessons").
                    OfType<Student>().
                    ToList();

                var teachers = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();

                var addresses = myDB.Addresses.ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    Include("PresentStudents").
                    ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                toReturn = myDB.Courses.
                    Include("Teachers").
                    ToList();
            }
            return toReturn;
        }

        public static List<Lesson> GetAllLessons() // Returns a List<Lessons> representing all the lessons in the DB
        {
            var toReturn = new List<Lesson>();
            using (var myDB = new VirtualCollegeContext())
            {
                var students = myDB.Users.
                    Include("Lessons").
                    Include("PresentLessons").
                    OfType<Student>().
                    ToList();

                var teachers = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();

                var addresses = myDB.Addresses.ToList();

                toReturn = myDB.Lessons.
                    Include("Students").
                    Include("PresentStudents").
                    ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                var courses = myDB.Courses.
                    Include("Teachers").
                    ToList();
            }
            return toReturn;
        }

        public static List<Course> GetAllCourses(Student _studentToGetCoursesOf) // Returns a List<Course> for a specific student input
        {
            // t stands for toReturn
            var t = new List<Course>();
            using (var myDB = new VirtualCollegeContext())
            {
                var students = myDB.Users.
                    Include("Lessons").
                    Include("PresentLessons").
                    OfType<Student>().
                    ToList();

                var teachers = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();

                var addresses = myDB.Addresses.ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    Include("PresentStudents").
                    ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                var courses = myDB.Courses.
                    Include("Teachers").
                    ToList();

                foreach (Lesson lesson in students.Find(s => s.UserId == _studentToGetCoursesOf.UserId).Lessons) // Get the input student in the list of users and foreach lesson that he has
                {
                    if (t.FindAll(c => c.Title == lesson.Course.Title).Count == 0) t.Add(lesson.Course); // Add the course to the list that we return if it's not already in it
                }
            }
            return t;
        }

        public static List<Lesson> GetLessonsFromCourse(Teacher _teacherToGetLessonsOf, Course _specificcourse) // Returns a List<Lesson> in a specific course for a specified teacher
        {
            var t = new List<Lesson>();
            using (var myDB = new VirtualCollegeContext())
            {
                var students = myDB.Users.
                    Include("Lessons").
                    Include("PresentLessons").
                    OfType<Student>().
                    ToList();

                var teachers = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();

                var addresses = myDB.Addresses.ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    Include("PresentStudents").
                    ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                var courses = myDB.Courses.
                    Include("Teachers").
                    ToList();

                List<Lesson> az = new List<Lesson>(); // Initialize a lsit
                var x = teachers.Find(te => te.UserId == _teacherToGetLessonsOf.UserId); // Gets the corresponding teacher
                az = x.Lessons.ToList(); // Store the teacher's lessons in the list
                if (az.Count != 0) // If the list is not empty (if the teacher has lessons)
                {
                    foreach (Lesson lesson in az) // Go through each of them
                    {
                        if (lesson.Course.CourseId == _specificcourse.CourseId) t.Add(lesson); // If one's course matchesthe input course, add it to the list that we return later
                    }
                }
            }
            return t;
        }

        public static List<Grade> GetAllGrades(Course _courseToGetGradesOf) // Returns a List<Grade> for a specified course
        {
            var toReturn = new List<Grade>();
            using (var myDB = new VirtualCollegeContext())
            {
                var students = myDB.Users.
                    Include("Lessons").
                    Include("PresentLessons").
                    OfType<Student>().
                    ToList();

                var teachers = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();

                var addresses = myDB.Addresses.ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    Include("PresentStudents").
                    ToList();

                var payments = myDB.Payments.ToList();

                var courses = myDB.Courses.
                    Include("Teachers").
                    ToList();

                toReturn = myDB.Grades.ToList().FindAll(g => g.Course.CourseId == _courseToGetGradesOf.CourseId);
            }
            return toReturn;
        }

        public static List<Grade> GetAllGradesFromStudent(Course _courseToGetGradesOf, Student _selectedStudent) // Returns List<Grade> in the specifed course for the input student
        {
            var grades = new List<Grade>();
            var gradesFromStudent = new List<Grade>(); // List that we return later
            using (var myDB = new VirtualCollegeContext())
            {
                var students = myDB.Users.
                    Include("Lessons").
                    Include("PresentLessons").
                    OfType<Student>().
                    ToList();

                var teachers = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();

                var addresses = myDB.Addresses.ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    Include("PresentStudents").
                    ToList();

                var payments = myDB.Payments.ToList();

                var courses = myDB.Courses.Include("Teachers").ToList();

                grades = GetAllGrades(courses.Find(c => c.CourseId == _courseToGetGradesOf.CourseId)); // Calls the previous method
                foreach (var grade in grades)
                {
                    if (grade.Student.UserId == students.Find(s => s.UserId == _selectedStudent.UserId).UserId) // If the current grade's student matches our student
                    {
                        gradesFromStudent.Add(grades.Find(g => g.GradeId == grade.GradeId)); // Add it to the list we return
                    }
                        
                }
            }
            return gradesFromStudent;
        }

        public static bool StudentIsPresent(Student _inputStudent, Lesson _inputLesson) // Returns a bool indicating wether a student was set as present in a specified lesson
        {
            bool isPresent = false;
            using (var myDB = new VirtualCollegeContext())
            {
                var students = myDB.Users.
                    Include("Lessons").
                    Include("PresentLessons").
                    OfType<Student>().
                    ToList();

                var teachers = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();

                var addresses = myDB.Addresses.ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    Include("PresentStudents").
                    ToList();

                var payments = myDB.Payments.ToList();

                var courses = myDB.Courses.Include("Teachers").ToList();

                if (lessons.Find(l => l.LessonId == _inputLesson.LessonId).PresentStudents.Contains(students.Find(s => s.UserId == _inputStudent.UserId))) isPresent = true;
            }
            return isPresent;
        }
        #endregion

        #region Get all that match text - methods that reutrn a List<T> of all the elements that match some text
        // For optimization, we could use the same functions as before but set the parameters as optional and handle "" as all

        public static List<Student> GetAllStudentsThatMatchFullName(string _fullName) // Returns a List<Student> in the DB whose full names math the input string
        {
            var toReturn = new List<Student>();
            using (var myDB = new VirtualCollegeContext())
            {
                // Getting all these values is probably not necessary in this case but we prefer to do it anyways, just in case
                var addresses = myDB.Addresses.ToList();

                var teachers = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();

                var courses = myDB.Courses.
                    Include("Teachers")
                    .ToList();

                var lessons = myDB.Lessons.
                    Include("Students")
                    .ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                toReturn = GetAllStudents().
                    FindAll(s => s.FullName.ToLower().Contains(_fullName.ToLower()));
            }
            return toReturn;
        }

        public static List<Teacher> GetAllTeachersThatMatchFullName(string _fullName) // Returns a List<Teacher> in the DB whose full names math the input string
        {
            var toReturn = new List<Teacher>();
            using (var myDB = new VirtualCollegeContext())
            {
                var addresses = myDB.Addresses.ToList();

                var students = myDB.Users.
                    Include("Lessons").
                    Include("PresentLessons").
                    OfType<Student>().
                    ToList();

                var courses = myDB.Courses.
                    Include("Teachers")
                    .ToList();

                var lessons = myDB.Lessons.
                    Include("Students")
                    .ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                toReturn = GetAllTeachers().
                    FindAll(s => s.FullName.ToLower().Contains(_fullName.ToLower()));
            }
            return toReturn;
        }

        public static List<Course> GetAllCoursesThatMatchTitle(string _courseTitle) // Returns a List<Course> in the DB whose title math the input string
        {
            var toReturn = new List<Course>();
            using (var myDB = new VirtualCollegeContext())
            {
                var addresses = myDB.Addresses.ToList();

                var students = myDB.Users.
                    Include("Lessons").
                    Include("PresentLessons").
                    OfType<Student>().
                    ToList();

                var teachers = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    Include("PresentStudents").
                    ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                toReturn = GetAllCourses().
                    FindAll(c => c.Title.ToLower().Contains(_courseTitle.ToLower()));
            }
            return toReturn;
        }

        public static List<Lesson> GetAllLessonsThatMatchTitle(string _lessonTitle) // Returns a List<Lesson> in the DB whose course title math the input string
        {
            var toReturn = new List<Lesson>();
            using (var myDB = new VirtualCollegeContext())
            {
                var addresses = myDB.Addresses.ToList();

                var students = myDB.Users.
                    Include("Lessons").
                    Include("PresentLessons").
                    OfType<Student>().
                    ToList();

                var teachers = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();

                var courses = myDB.Courses.Include("Teachers").ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                toReturn = GetAllLessons().
                    FindAll(l => l.Course.Title.ToLower().Contains(_lessonTitle.ToLower()));
            }
            return toReturn;
        }

        public static List<Student> GetAllStudentsOfTutorThatMatchFullName(Teacher _tutor, string _fullNameSearch) // Returns a List<Student> in the DB whose full names match the input sting and have the specified teacher as tutor
        {
            var toReturn = new List<Student>();
            using (var myDB = new VirtualCollegeContext())
            {
                var addresses = myDB.Addresses.ToList();

                var teachers = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();

                var courses = myDB.Courses.
                    Include("Teachers")
                    .ToList();

                var lessons = myDB.Lessons.
                    Include("Students")
                    .ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                var students = myDB.Users.Include("Lessons").Include("PresentLessons").OfType<Student>().ToList();

                toReturn = teachers.Find(t => t.UserId == _tutor.UserId).Tutoring.ToList().FindAll(s => s.FullName.ToLower().Contains(_fullNameSearch.ToLower()));
            }
            return toReturn;
        }
        #endregion

        #region Add & update entitites - methods that manage the addition and modification of entities in the DB
        // By convention, we return bool instead of void (this is specially useful when coding, it allows for a better debugging)

        public static bool CreateStudent(Student _userToAdd, Address _addressToAdd) // Creates new student if doesn't already exist (checks email)
        {
            bool done = false;
            using (var myDB = new VirtualCollegeContext())
            {
                var students = myDB.Users.
                    Include("Lessons").
                    Include("PresentLessons").
                    OfType<Student>().
                    ToList();

                var teachers = myDB.Users.Include("Courses").OfType<Teacher>().ToList();

                var addresses = myDB.Addresses.ToList();

                var courses = myDB.Courses.
                    Include("Teachers").
                    ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    Include("PresentStudents").
                    ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                if (_addressToAdd.AddressLine2 == "") _addressToAdd.AddressLine2 = null; // Often, the address line 2 is empty. If it is, we set it as null (to match the DB)

                Address match = addresses.Find(a => a.ToString() == _addressToAdd.ToString()); // We check if the input address already exists in the DB. To do so, we compare the custom ToString methods of the Address class

                if (students.FindAll(s => s.EmailAddress == _userToAdd.EmailAddress).Count() == 0) // Get the list of users that have the same email address. If it is empty, then we can proceeed
                {
                    if (match == null) _userToAdd.Address = _addressToAdd; // If we didn't find any mathcing address, we can simply assign the input address to the user to add
                    else _userToAdd.Address = match; // Else, we set the address to the one that match
                    Student temp = _userToAdd; // We create a clean entity matching the student we're adding
                    temp.Tutor = teachers.Find(t => t.UserId == temp.Tutor.UserId); // Setting his tutor
                    myDB.Users.Add(temp); // adding the student
                    done = true; // Setting done as true (set as false by default)
                }
                myDB.SaveChanges();
            }
            return done;
        }

        public static bool UpdateStudent(Student _userToEdit, Address _addressToEdit) // Updates the info of a specific student
        {
            bool done = false;
            using (var myDB = new VirtualCollegeContext())
            {
                var students = myDB.Users.
                    Include("Lessons").
                    Include("PresentLessons").
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
                    Include("PresentStudents").
                    ToList();

                var grades = myDB.Grades.ToList();
                var payments = myDB.Payments.ToList();
                var addresses = myDB.Addresses.ToList();

                var studentToModify = students.Find(s => s.UserId == _userToEdit.UserId); // Get the student
                var oldAddress = addresses.Find(a => a.AddressId == studentToModify.Address.AddressId); // Get his old address

                if (_addressToEdit.AddressLine2 == "") _addressToEdit.AddressLine2 = null;

                var desc = _addressToEdit.ToString();
                Address match = addresses.Find(a => a.ToString() == desc); // Find if the new address exists

                if (match == null) // If it doesn't
                {
                    myDB.Addresses.Add(new Address() // Create a new one
                    {
                        AddressLine1 = _addressToEdit.AddressLine1,
                        AddressLine2 = _addressToEdit.AddressLine2,
                        Postcode = _addressToEdit.Postcode,
                        City = _addressToEdit.City,
                        State = _addressToEdit.State,
                        Country = _addressToEdit.Country
                    });
                    myDB.SaveChanges();
                    addresses = myDB.Addresses.ToList();
                    studentToModify.Address = addresses[addresses.Count - 1]; // Set the students address to be the last one (the one we juste created)
                }
                else studentToModify.Address = addresses.Find(a => a.AddressId == match.AddressId);

                studentToModify.EmailAddress = _userToEdit.EmailAddress;
                studentToModify.Password = _userToEdit.Password;
                studentToModify.PhoneNumber = _userToEdit.PhoneNumber;
                if (_userToEdit.Tutor != null) studentToModify.Tutor = teachers.Find(t => t.UserId == _userToEdit.Tutor.UserId);
                studentToModify.Fees = _userToEdit.Fees;
                myDB.SaveChanges();

                if (oldAddress.Users.Count == 0) myDB.Addresses.Remove(oldAddress); // If the old address isn't used anymore, we can just remove it from the DB

                done = true;
                myDB.SaveChanges();
            }
            return done;
        }

        public static bool CreateTeacher(Teacher _userToAdd, Address _addressToAdd) // Creates new teacher if doesn't already exist (checks email)
        {
            bool done = false;
            using (var myDB = new VirtualCollegeContext())
            {
                var users = myDB.Users.
                    ToList();

                var teachers = myDB.Users.Include("Courses").OfType<Teacher>().ToList();

                var addresses = myDB.Addresses.ToList();

                var courses = myDB.Courses.
                    Include("Teachers").
                    ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    Include("PresentStudents").
                    ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                if (_addressToAdd.AddressLine2 == "") _addressToAdd.AddressLine2 = null;

                // Identical process as the above function
                Address match = addresses.Find(a => a.ToString() == _addressToAdd.ToString());

                if (users.FindAll(s => s.EmailAddress == _userToAdd.EmailAddress).Count() == 0)
                {
                    if (match == null) _userToAdd.Address = _addressToAdd;
                    else _userToAdd.Address = match;
                    myDB.Users.Add(_userToAdd);
                    done = true;
                }
                myDB.SaveChanges();
            }
            return done;
        }

        public static bool UpdateTeacher(Teacher _userToEdit, Address _addressToEdit) // Updates the info of a specific teahcer
        {
            bool done = false;
            using (var myDB = new VirtualCollegeContext())
            {
                var students = myDB.Users.
                    Include("Lessons").
                    Include("PresentLessons").
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
                    Include("PresentStudents").
                    ToList();

                var grades = myDB.Grades.ToList();
                var payments = myDB.Payments.ToList();
                var addresses = myDB.Addresses.ToList();

                // Process is identical to the previous method (bit less work to do, things could have been grouped up)
                var teacherToModify = teachers.Find(s => s.UserId == _userToEdit.UserId);
                var oldAddress = addresses.Find(a => a.AddressId == teacherToModify.Address.AddressId);

                if (_addressToEdit.AddressLine2 == "") _addressToEdit.AddressLine2 = null;

                var desc = _addressToEdit.ToString();
                Address match = addresses.Find(a => a.ToString() == desc);

                if (match == null)
                {
                    myDB.Addresses.Add(new Address()
                    {
                        AddressLine1 = _addressToEdit.AddressLine1,
                        AddressLine2 = _addressToEdit.AddressLine2,
                        Postcode = _addressToEdit.Postcode,
                        City = _addressToEdit.City,
                        State = _addressToEdit.State,
                        Country = _addressToEdit.Country
                    });
                    myDB.SaveChanges();
                    addresses = myDB.Addresses.ToList();
                    teacherToModify.Address = addresses[addresses.Count - 1];
                }
                else teacherToModify.Address = addresses.Find(a => a.AddressId == match.AddressId);

                teacherToModify.EmailAddress = _userToEdit.EmailAddress;
                teacherToModify.Password = _userToEdit.Password;
                teacherToModify.PhoneNumber = _userToEdit.PhoneNumber;
                myDB.SaveChanges();

                if (oldAddress.Users.Count == 0) myDB.Addresses.Remove(oldAddress);

                done = true;
                myDB.SaveChanges();
            }
            return done;
        }

        public static bool CreateCourse(Course _courseToAdd) // Creates a new course entity and adds it to the DB
        {
            bool done = false;
            using (var myDB = new VirtualCollegeContext())
            {
                var teachers = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();

                var courses = myDB.Courses.
                    Include("Teachers")
                    .ToList();

                var addresses = myDB.Addresses.ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    Include("PresentStudents").
                    ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                if (courses.FindAll(c => c.ToString() == _courseToAdd.ToString()).Count == 0) // If course doesn't already exist
                {
                    Course courseToAdd = new Course // Create new create
                    {
                        Title = _courseToAdd.Title,
                        Credits = _courseToAdd.Credits,
                        ReferentTeacher = teachers.Find(x => x.FullName == _courseToAdd.ReferentTeacher.FullName)
                    };

                    foreach (Teacher t in _courseToAdd.Teachers) courseToAdd.Teachers.Add(teachers.Find(x => x.FullName == t.FullName)); // Associate the teachers

                    myDB.Courses.Add(courseToAdd);
                    done = true;
                }
                myDB.SaveChanges();
            }
            return done;
        }

        public static bool UpdateCourse(Course _courseToEdit) // Updates a course's info (identifies it by CourseId)
        {
            using (var myDB = new VirtualCollegeContext())
            {
                var students = myDB.Users.
                    Include("Lessons").
                    Include("PresentLessons").
                    OfType<Student>().
                    ToList();

                var teachers = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();

                var addresses = myDB.Addresses.ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    Include("PresentStudents").
                    ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                var courses = myDB.Courses.
                    Include("Teachers").
                    ToList();

                var courseToEdit = courses.Find(c => c.CourseId == _courseToEdit.CourseId);
                courseToEdit.Title = _courseToEdit.Title;
                courseToEdit.Credits = _courseToEdit.Credits;
                courseToEdit.ReferentTeacher = teachers.Find(x => x.UserId == _courseToEdit.ReferentTeacher.UserId);
                courseToEdit.Teachers.Clear();
                foreach (Teacher teacher in _courseToEdit.Teachers) courseToEdit.Teachers.Add(teachers.Find(x => x.UserId == teacher.UserId));
                myDB.SaveChanges();
            }
            return true;
        }

        public static bool CreateLesson(Lesson _lessonToAdd) // Create and new lesson enitty and adds it to the DB
        {
            bool done = false;
            using (var myDB = new VirtualCollegeContext())
            {
                var students = myDB.Users.
                    Include("Lessons").
                    Include("PresentLessons").
                    OfType<Student>().
                    ToList();

                var teachers = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();

                var courses = myDB.Courses.
                    Include("Teachers")
                    .ToList();

                var addresses = myDB.Addresses.ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    Include("PresentStudents").
                    ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                if (lessons.FindAll(l => l.ToString() == _lessonToAdd.ToString()).Count == 0) // If lesson doesn't already exist
                {
                    Lesson lessonToAdd = new Lesson() // Create it
                    {
                        Teacher = teachers.Find(t => t.UserId == _lessonToAdd.Teacher.UserId),
                        Course = courses.Find(c => c.CourseId == _lessonToAdd.Course.CourseId),
                        Day = _lessonToAdd.Day,
                        Duration = _lessonToAdd.Duration,
                        Hour = _lessonToAdd.Hour,
                        RoomName = _lessonToAdd.RoomName
                    };

                    foreach (Student stu in _lessonToAdd.Students) lessonToAdd.Students.Add(students.Find(s => s.UserId == stu.UserId)); // Add the students that are enrolled to it
                    myDB.Lessons.Add(lessonToAdd);
                    done = true;

                }
                myDB.SaveChanges();
            }
            return done;
        }

        public static bool UpdateLesson(Lesson _lessonToEdit) // Updates a lesson's info (identifies it by LessonId)
        {
            bool done = false;
            using (var myDB = new VirtualCollegeContext())
            {
                var students = myDB.Users.
                    Include("Lessons").
                    Include("PresentLessons").
                    OfType<Student>().
                    ToList();

                var teachers = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();

                var addresses = myDB.Addresses.ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    Include("PresentStudents").
                    ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                var courses = myDB.Courses.
                    Include("Teachers").
                    ToList();

                var lessonToChange = lessons.Find(l => l.LessonId == _lessonToEdit.LessonId);
                lessonToChange.RoomName = _lessonToEdit.RoomName;
                lessonToChange.Day = _lessonToEdit.Day;
                lessonToChange.Hour = _lessonToEdit.Hour;
                lessonToChange.Duration = _lessonToEdit.Duration;
                lessonToChange.Teacher = teachers.Find(t => t.UserId == _lessonToEdit.Teacher.UserId);
                lessonToChange.Students.Clear();
                foreach (Student student in _lessonToEdit.Students) lessonToChange.Students.Add(students.Find(s => s.UserId == student.UserId));

                myDB.SaveChanges();
                done = true;
            }
            return done;
        }

        public static bool AddPayment(Payment paymentToAdd) // Create a new payment. Error handling is done in the UI
        {
            bool done = true;
            using (var myDB = new VirtualCollegeContext())
            {
                var users = myDB.Users.
                    ToList();

                var addresses = myDB.Addresses.ToList();

                var courses = myDB.Courses.
                    Include("Teachers").
                    ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    Include("PresentStudents").
                    ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                Student userToAddPayment = (Student)users.Find(u => u.UserId == paymentToAdd.Student.UserId); // Get the student doing the payment
                userToAddPayment.Payments.Add(new Payment() { Amount = paymentToAdd.Amount, Date = paymentToAdd.Date, Student = userToAddPayment }); // Add a new payment
                userToAddPayment.Fees -= paymentToAdd.Amount; // Reduce his fees (what he still has to pay)
                userToAddPayment.Paid += paymentToAdd.Amount; // Increase what he paid
                myDB.SaveChanges();
            }
            return done;
        }

        public static bool AddGrade(Grade _inputGrade, Student _inputStudent) // Adds the specified grade to the input student
        {
            bool done = false;
            using (var myDB = new VirtualCollegeContext())
            {
                var students = myDB.Users.
                    Include("Lessons").
                    Include("PresentLessons").
                    OfType<Student>().
                    ToList();

                var teachers = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();

                var addresses = myDB.Addresses.ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    Include("PresentStudents").
                    ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                var courses = myDB.Courses.
                    Include("Teachers").
                    ToList();

                myDB.Grades.Add(new Grade() // Creates a new grade matching the specified one and adds it directly
                {
                    ExamName = _inputGrade.ExamName,
                    Course = courses.Find(c => c.CourseId == _inputGrade.Course.CourseId),
                    Mark = _inputGrade.Mark,
                    Coefficient = _inputGrade.Coefficient,
                    Student = students.Find(s => s.UserId == _inputStudent.UserId)
                });

                myDB.SaveChanges();
                done = true;
            }
            return done;
        }

        public static bool UpdateGrade(Grade _gradeToEdit) // Edits a specific grade
        {
            bool done = false;
            using (var myDB = new VirtualCollegeContext())
            {
                var students = myDB.Users.
                    Include("Lessons").
                    Include("PresentLessons").
                    OfType<Student>().
                    ToList();

                var teachers = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();

                var addresses = myDB.Addresses.ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    Include("PresentStudents").
                    ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                var courses = myDB.Courses.
                    Include("Teachers").
                    ToList();

                var gradeToChange = grades.Find(g => g.GradeId == _gradeToEdit.GradeId); // Identifies the grade to edit by its Id
                gradeToChange.Mark = _gradeToEdit.Mark;
                gradeToChange.ExamName = _gradeToEdit.ExamName;
                gradeToChange.Coefficient = _gradeToEdit.Coefficient;

                myDB.SaveChanges();
                done = true;
            }
            return done;
        }

        public static bool SetStudentAsPresent(Student _inputStudent, Lesson _inputLesson) // Sets a student as present
        {
            bool done = false;
            using (var myDB = new VirtualCollegeContext())
            {
                var students = myDB.Users.
                    Include("Lessons").
                    Include("PresentLessons").
                    OfType<Student>().
                    ToList();

                var teachers = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();

                var addresses = myDB.Addresses.ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    Include("PresentStudents").
                    Include("PresentStudents").
                    ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                var courses = myDB.Courses.
                    Include("Teachers").
                    ToList();

                var realStudent = students.Find(s => s.UserId == _inputStudent.UserId); // Identifies the student
                var realLesson = lessons.Find(l => l.LessonId == _inputLesson.LessonId); // Identifies the lesson
                if (!realLesson.PresentStudents.Contains(realStudent)) realLesson.PresentStudents.Add(realStudent); // Checks if the collection of present students contains the student we chose and adds him to it if not

                myDB.SaveChanges();
                done = true;
            }
            return done;
        }

        public static bool SetStudentAsNotPresent(Student _inputStudent, Lesson _inputLesson) // Sets a student as not presen 
        {
            bool done = false;
            using (var myDB = new VirtualCollegeContext())
            {
                var students = myDB.Users.
                    Include("Lessons").
                    Include("PresentLessons").
                    OfType<Student>().
                    ToList();

                var teachers = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();

                var addresses = myDB.Addresses.ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    Include("PresentStudents").
                    Include("PresentStudents").
                    ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                var courses = myDB.Courses.
                    Include("Teachers").
                    ToList();

                // Opposite of previous method
                var realStudent = students.Find(s => s.UserId == _inputStudent.UserId);
                var realLesson = lessons.Find(l => l.LessonId == _inputLesson.LessonId);
                if (realLesson.PresentStudents.Contains(realStudent)) realLesson.PresentStudents.Remove(realStudent);

                myDB.SaveChanges();
                done = true;
            }
            return done;
        }
        #endregion

        #region Remove entities - methods that remove specified entities from the DB
        public static bool RemoveUser(User _userToRemove) // Removes a single user (type does't matter)
        {
            bool done = false;
            using (var myDB = new VirtualCollegeContext())
            {
                var users = myDB.Users.ToList();

                var courses = myDB.Courses.
                    Include("Teachers").
                    ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    Include("PresentStudents").
                    ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                var addresses = myDB.Addresses.ToList();

                var userToRemove = users.Find(u => u.UserId == _userToRemove.UserId); // Gets the user
                var addressToCheck = addresses.Find(a => a.AddressId == userToRemove.Address.AddressId); // Gets his address

                myDB.Users.Remove(userToRemove); // Removes the user
                if (addressToCheck.Users.Count == 0) myDB.Addresses.Remove(addressToCheck); // If address isn't used anymore, remove it
                myDB.SaveChanges();
                done = true;
            }
            return done;
        }

        public static bool RemoveUser(List<User> _usersToRemove) // Removes a list of users (in case we had the ability to do multiple selections)
        {
            foreach (User u in _usersToRemove) RemoveUser(u); // Calls the previous method for each user we ask are asked to remove
            return true;
        }


        // The following methods are void (for debuggin needs when implementing our UI)
        public static void RemoveCourse(Course _courseToRemove) // Remove a course
        {
            if (_courseToRemove != null) // Little error in the UI so the check goes here
            {
                using (var myDB = new VirtualCollegeContext())
                {
                    var students = myDB.Users.
                           Include("Lessons").
                           Include("PresentLessons").
                           OfType<Student>().
                           ToList();

                    var teachers = myDB.Users.
                        Include("Courses").
                        OfType<Teacher>().
                        ToList();

                    var addresses = myDB.Addresses.ToList();

                    var lessons = myDB.Lessons.
                        Include("Students").
                        Include("PresentStudents").
                        ToList();

                    var payments = myDB.Payments.ToList();

                    var courses = myDB.Courses.Include("Teachers").ToList();

                    var lessonsToRemove = lessons.FindAll(l => l.Course.CourseId == _courseToRemove.CourseId); // Gets all lessons of the course
                    myDB.Lessons.RemoveRange(lessonsToRemove); // Removes all of them
                    myDB.SaveChanges();

                    // One all lessons are removed, we can now remove the course itself
                    myDB.Courses.Remove(myDB.Courses.Find(_courseToRemove.CourseId));
                    myDB.SaveChanges();
                }
            }
        }

        public static void RemoveGrade(Grade _gradeToRemove) // Removes a grade
        {
            using (var myDB = new VirtualCollegeContext())
            {
                myDB.Grades.Remove(myDB.Grades.Find(_gradeToRemove.GradeId));
                myDB.SaveChanges();
            }
        }

        public static void RemoveLesson(Lesson _lessonToRemove) // Removes a lesson
        {
            if (_lessonToRemove != null)
            {
                using (var myDB = new VirtualCollegeContext())
                {
                    myDB.Lessons.Remove(myDB.Lessons.Find(_lessonToRemove.LessonId));
                    myDB.SaveChanges();
                }
            }
        }
        #endregion
        #endregion
    }
}