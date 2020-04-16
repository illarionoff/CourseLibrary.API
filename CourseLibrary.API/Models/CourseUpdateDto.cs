using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CourseLibrary.API.ValidationAttributes;

namespace CourseLibrary.API.Models
{
    public class CourseUpdateDto : CourseChangeDto
    {
        [Required(ErrorMessage = "Should not be empty")]
        public override string Description { get => base.Description; set => base.Description = value; }
    }
}
