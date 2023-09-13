using StudentsApiAzureFunction.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsApiAzureFunction.Dal
{
    public interface IStudentRepo
    {
        public List<Student> GetStudents();
        public Student GetStudent(int id);
        public Student CreateStudent(Student student);  
        public void UpdateStudent(Student student);
        public void DeleteStudent(int id);
    }
}
