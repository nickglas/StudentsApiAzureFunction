using StudentsApiAzureFunction.Dal;
using StudentsApiAzureFunction.DTO;
using StudentsApiAzureFunction.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsApiAzureFunction.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo _repo;

        public StudentService(IStudentRepo repo)
        {
            _repo = repo;   
        }

        public Student CreateStudent(StudentCreateDto dto)
        {
            try
            {
                return _repo.CreateStudent(new Student() { Name = dto.Name });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void DeleteStudent(int id)
        {
            try
            {
                _repo.DeleteStudent(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public Student GetStudent(int id)
        {
            try
            {
                return _repo.GetStudent(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public List<Student> GetStudents()
        {
            try
            {
                return _repo.GetStudents();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void UpdateStudent(UpdateStudentDto dto)
        {
            try
            {
                Student existing = GetStudent(dto.Id);

                if (existing == null) throw new Exception("User not found");

                existing.Name = dto.Name;

                _repo.UpdateStudent(existing);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
