using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseLibrary.API.Entities;

namespace CourseLibrary.API.Models
{
    public class CourseCreationDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
