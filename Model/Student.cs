using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsApiAzureFunction.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        protected string password { get; set; } = "TotallyNotSavePassword";
    }
}
