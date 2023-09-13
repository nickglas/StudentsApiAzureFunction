using StudentsApiAzureFunction.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsApiAzureFunction.Dal
{
    public class StudentRepo : IStudentRepo
    {

        private List<Student> students = new List<Student>()
        {
            new Student(){Id = 1, Name = "Nick"},
            new Student(){Id = 2, Name = "Simon"}
        };

        private int generateId()
        {
            return students.Max(student => student.Id) + 1;
        }

        public Student CreateStudent(Student student)
        {
            student.Id = generateId();
            students.Add(student);
            return student;
        }

        public void DeleteStudent(int id)
        {
            students = students.Where(s => s.Id != id).ToList();
        }

        public Student GetStudent(int id)
        {
            return students.Where(s => s.Id == id).First();
        }

        public List<Student> GetStudents()
        {
            return students;
        }

        public void UpdateStudent(Student student)
        {
            students = students
              .Select(s => s.Id == student.Id ? student : s)
              .ToList();
        }
    }
}
