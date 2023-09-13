using StudentsApiAzureFunction.DTO;
using StudentsApiAzureFunction.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsApiAzureFunction.Service
{
    public interface IStudentService
    {
        public List<Student> GetStudents();
        public Student GetStudent(int id);
        public Student CreateStudent(StudentCreateDto dto);
        public void UpdateStudent(UpdateStudentDto dto);
        public void DeleteStudent(int id);
    }
}
