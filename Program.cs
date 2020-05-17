using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

#nullable enable

namespace CodeFirst
{
    public class Program
    {
        private static void Main(string[] args)
        {
            using (var context = new MyContext())
            {
                // Create and save a new Students
                //Console.WriteLine("Adding new students");

                //var student = new Student
                //{
                //    FirstMidName = "Alain",
                //    LastName = "Bomer",
                //    EnrollmentDate = DateTime.Parse(DateTime.Today.ToString())
                //};

                //context.Students.Add(student);

                //var student1 = new Student
                //{
                //    FirstMidName = "Mark",
                //    LastName = "Upston",
                //    EnrollmentDate = DateTime.Parse(DateTime.Today.ToString())
                //};

                //context.Students.Add(student1);
                //context.SaveChanges();

                // Display all Students from the database

                var students  = context.Students.OrderBy(x => x.FirstMidName).Select(x => x).ToList();
                //var students = (from s in context.Students
                //                orderby s.FirstMidName
                //                select s).ToList<Student>();

                Console.WriteLine("Retrieve all Students from the database:");

                foreach (var stdnt in students)
                {
                    string name = stdnt.FirstMidName + " " + stdnt.LastName;
                    Console.WriteLine("ID: {0}, Name: {1}", stdnt.ID, name);
                }

                Console.WriteLine("Press any key to exit...");
                
            }

            Console.ReadKey();
        }

    }

    public class Student
    {
        [Key]
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string City { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }

    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        [Column(TypeName = "numeric")]
        public int Number { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }

    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        [Key]
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }
    }

    public class MyContext : DbContext
    {
        public MyContext() : base("name = MyContextDB") { }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Student> Students { get; set; }
    }
}
