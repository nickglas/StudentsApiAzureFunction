﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsApiAzureFunction.DTO
{
    public class StudentCreateDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
    }
}
