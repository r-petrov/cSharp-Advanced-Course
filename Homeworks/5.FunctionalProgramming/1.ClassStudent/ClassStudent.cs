using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.ClassStudent
{
    class ClassStudent
    {
        static void Main(string[] args)
        {
            //problem #1 solution
            List<Student> students = new List<Student>()
        {
            new Student("Sara", "Mills", 22, "12364578", "+44987456123", "smills0@marketwatch.com",
                new List<int>() {6, 6, 5, 3, 4, 5}, "1"),
            new Student("Daniel", "Carter", 23, "12361479", "+44988456673", "dcarter1@buzzfeed.com",
                new List<int>() {6, 5, 4, 4, 4, 5}, "1"),
            new Student("Aaron", "Gibson", 26, "12361480", "+44987445842", "smills0@marketwatch.com",
                new List<int>() {4, 6, 3, 3, 4, 5}, "1"),
            new Student("William", "Alexander", 22, "12364601", "+3592 / 8856453", "walexander3@hexun.com",
                new List<int>() {2, 4, 5, 2, 2, 5}, "2"),
            new Student("Mildred", "Hansen", 24, "12364602", "02 / 7887823", "mhansen4@abv.bg",
                new List<int>() {6, 6, 5, 6, 4, 5}, "2"),
            new Student("Antonio", "Gonzalez", 26, "12364581", "+44987400863", "agonzalez5@zdnet.com",
                new List<int>() {5, 3, 4, 5, 4, 5}, "1"),
            new Student("Cheryl", "Gray", 23, "12364582", "+44987756032", "cgray6@yahoo.com",
                new List<int>() {6, 6, 5, 6, 4, 5}, "1"),
            new Student("Craig", "King", 26, "12361404", "+44878450567", "cking7@cyberchimps.com",
                new List<int>() {6, 5, 3, 3, 4, 5}, "2"),
            new Student("Craig", "Ellis", 24, "12314603", "+3592 / 78785456", "cellis8@abv.bg",
                new List<int>() {3, 2, 2, 5, 4, 5}, "2"),
            new Student("Andrea", "Harper", 19, "12361405", "+359 2 7892564", "aharper9@facebook.com",
                new List<int>() {6, 6, 5, 6, 5, 5}, "2"),
        };

            //Problem 2.	Students by Group

            //var studentsGroup = students.Where(student => student.GroupNumber == "2").OrderBy(student => student.FirstName);

            var studentsGroup =
                from student in students
                where student.GroupNumber == "2"
                orderby student.FirstName
                select student;

            //foreach (var student in studentsGroup)
            //{
            //    Console.WriteLine("First name: {0}\nLast name: {1}\nAge: {2}\nFaculty number: {3}\nPhone number: {4}\nEmail: {5}\nMarks: {6}\nGroup number {7}\n", student.FirstName, student.LastName, student.Age, student.FacultyNumber,
            //        student.Phone, student.Email, string.Join(", ", student.Marks), student.GroupNumber);
            //}
            //Console.WriteLine();

            //Problem 3.	Students by First and Last Name

            //var studentsGruppedByFirstName = students.Where(student => student.FirstName.CompareTo(student.LastName) == -1);

            var studentsGruppedByFirstName =
                from student1 in students
                where student1.FirstName.CompareTo(student1.LastName) == -1
                select student1;

            //foreach (var st in studentsGruppedByFirstName)
            //{
            //    Console.WriteLine("First name: {0}\nLast name: {1}\n", st.FirstName, st.LastName);
            //}
            //Console.WriteLine();

            //Problem 4.	Students by Age

            var studentsGrouppedByAge =
                from student2 in students
                where student2.Age > 18 && student2.Age < 24
                select new {student2.FirstName, student2.LastName, student2.Age};

            //foreach (var student in studentsGrouppedByAge)
            //{
            //    Console.WriteLine(student);
            //}

            //Problem 5.	Sort Students

            //var studentsSortedByNames =
            //    students.OrderByDescending(student => student.FirstName).ThenByDescending(student => student.LastName);

            var studentsSortedByNames =
                from student3 in students
                orderby student3.FirstName descending, student3.LastName descending
                select student3;
                
            //foreach (var student in studentsSortedByNames)
            //{
            //    Console.WriteLine("First name: {0}\nLast name: {1}\n", student.FirstName, student.LastName);
            //}
            //Console.WriteLine();

            //Problem 6.	Filter Students by Email Domain
            var filterStudentsByEmail = students.Where(student => student.Email.IndexOf("@abv.bg") != -1);

            //foreach (var student in filterStudentsByEmail)
            //{
            //    Console.WriteLine("First name: {0}\nLast name: {1}\nEmail: {2}\n", student.FirstName, student.LastName,
            //        student.Email);
            //}
            //Console.WriteLine();

            //Problem 7.	Filter Students by Phone

            var filterStudentsByPhone =
                students.Where(
                    student =>
                        student.Phone.IndexOf("02 /") == 0 || student.Phone.IndexOf("+3592 /") == 0 ||
                        student.Phone.IndexOf("+359 2") == 0);

            //foreach (var student in filterStudentsByPhone)
            //{
            //    Console.WriteLine("First name: {0}\nLast name: {1}\nPhone: {2}\n", student.FirstName, student.LastName,
            //        student.Phone);
            //}
            //Console.WriteLine();

            //Problem 8.	Excellent Students

            var excelentStudents = students.Where(student => student.Marks.IndexOf(6)>=0).Select(student=>new {FullName=student.FirstName+" "+student.LastName, Marks=student.Marks});

            //foreach (var student in excelentStudents)
            //{
            //    Console.WriteLine("Full name: {0}\nMarks: {1}\n", student.FullName,
            //        string.Join(", ", student.Marks));
            //}
            //Console.WriteLine();

            //Problem 9.	Weak Students
            var weakStudents = students.Where(student => student.Marks.Count(mark => mark < 3) == 2).Select(student=>new { FullName = student.FirstName + " " + student.LastName, Marks = student.Marks });

            //foreach (var student in weakStudents)
            //{
            //    Console.WriteLine("Full name: {0}\nMarks: {1}\n", student.FullName,
            //        string.Join(", ", student.Marks));
            //}
            //Console.WriteLine();

            //Problem 10.	Students Enrolled in 2014

            var enrolledStudents = students.Where(student => student.FacultyNumber.IndexOf("14") == 4);

            foreach (var student in enrolledStudents)
            {
                Console.WriteLine("First name: {0}\nLast name: {1}\nFaculty number: {2}\n", student.FirstName, student.LastName,
                    student.FacultyNumber);
            }
            Console.WriteLine();
        }
    }
}
