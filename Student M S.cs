using System;
using System.Collections.Generic;

namespace StudentManagementSystemApp
{
    // Student class
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public List<Course> Courses { get; set; }

        public Student(int id, string name, DateTime dateOfBirth, string address)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Address = address;
            Courses = new List<Course>();
        }

        public void EnrollCourse(Course course)
        {
            Courses.Add(course);
            Console.WriteLine($"{Name} has enrolled in {course.CourseName}");
        }

        public void PrintReportCard()
        {
            Console.WriteLine($"Report Card for {Name}:");
            Console.WriteLine("Courses Enrolled: ");
            foreach (var course in Courses)
            {
                Console.WriteLine($"{course.CourseName} - Grade: {course.Grade}");
            }
        }

        public override string ToString()
        {
            return $"{Id}: {Name}, DOB: {DateOfBirth.ToShortDateString()}, Address: {Address}";
        }
    }

    // Course class
    public class Course
    {
        public string CourseName { get; set; }
        public string Grade { get; set; }
        public string Instructor { get; set; }
        public int Credits { get; set; }

        public Course(string courseName, string grade, string instructor, int credits)
        {
            CourseName = courseName;
            Grade = grade;
            Instructor = instructor;
            Credits = credits;
        }

        public override string ToString()
        {
            return $"{CourseName} (Instructor: {Instructor}, Credits: {Credits}, Grade: {Grade})";
        }
    }

    // StudentManagementSystem class
    public class StudentManagementSystem
    {
        private List<Student> students;

        public StudentManagementSystem()
        {
            students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
            Console.WriteLine($"Student {student.Name} has been added.");
        }

        public void RemoveStudent(int id)
        {
            var student = GetStudentById(id);
            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine($"Student {student.Name} has been removed.");
            }
            else
            {
                Console.WriteLine($"Student with ID {id} not found.");
            }
        }

        public void UpdateStudent(int id, string name, DateTime dateOfBirth, string address)
        {
            var student = GetStudentById(id);
            if (student != null)
            {
                student.Name = name;
                student.DateOfBirth = dateOfBirth;
                student.Address = address;
                Console.WriteLine($"Student {id} has been updated.");
            }
            else
            {
                Console.WriteLine($"Student with ID {id} not found.");
            }
        }

        public Student GetStudentById(int id)
        {
            return students.Find(student => student.Id == id);
        }

        public void PrintAllStudents()
        {
            Console.WriteLine("All Students:");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
    }

    // Main program
    class Program
    {
        static void Main(string[] args)
        {
            StudentManagementSystem sms = new StudentManagementSystem();

            while (true)
            {
                Console.WriteLine("\nStudent Management System");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Remove Student");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Enroll in Course");
                Console.WriteLine("5. Print Report Card");
                Console.WriteLine("6. Print All Students");
                Console.WriteLine("7. Exit");
                Console.Write("Choose an option: ");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        AddStudent(sms);
                        break;
                    case 2:
                        RemoveStudent(sms);
                        break;
                    case 3:
                        UpdateStudent(sms);
                        break;
                    case 4:
                        EnrollCourse(sms);
                        break;
                    case 5:
                        PrintReportCard(sms);
                        break;
                    case 6:
                        sms.PrintAllStudents();
                        break;
                    case 7:
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddStudent(StudentManagementSystem sms)
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Date of Birth (MM/DD/YYYY): ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Address: ");
            string address = Console.ReadLine();

            Student student = new Student(id, name, dateOfBirth, address);
            sms.AddStudent(student);
        }

        static void RemoveStudent(StudentManagementSystem sms)
        {
            Console.Write("Enter Student ID to remove: ");
            int id = int.Parse(Console.ReadLine());
            sms.RemoveStudent(id);
        }

        static void UpdateStudent(StudentManagementSystem sms)
        {
            Console.Write("Enter Student ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter New Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter New Date of Birth (MM/DD/YYYY): ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter New Address: ");
            string address = Console.ReadLine();

            sms.UpdateStudent(id, name, dateOfBirth, address);
        }

        static void EnrollCourse(StudentManagementSystem sms)
        {
            Console.Write("Enter Student ID: ");
            int id = int.Parse(Console.ReadLine());
            var student = sms.GetStudentById(id);
            if (student != null)
            {
                Console.Write("Enter Course Name: ");
                string courseName = Console.ReadLine();
                Console.Write("Enter Grade: ");
                string grade = Console.ReadLine();
                Console.Write("Enter Instructor: ");
                string instructor = Console.ReadLine();
                Console.Write("Enter Credits: ");
                int credits = int.Parse(Console.ReadLine());

                Course course = new Course(courseName, grade, instructor, credits);
                student.EnrollCourse(course);
            }
            else
            {
                Console.WriteLine($"Student with ID {id} not found.");
            }
        }

        static void PrintReportCard(StudentManagementSystem sms)
        {
            Console.Write("Enter Student ID: ");
            int id = int.Parse(Console.ReadLine());
            var student = sms.GetStudentById(id);
            if (student != null)
            {
                student.PrintReportCard();
            }
            else
            {
                Console.WriteLine($"Student with ID {id} not found.");
            }
        }
    }
}
