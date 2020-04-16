using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CourseLibrary.API.ValidationAttributes;

namespace CourseLibrary.API.Models
{
    [CourseTitleMustBeDifferentFromDescription]
    public abstract class CourseChangeDto // : IValidatableObject
    {
        [Required(ErrorMessage = "Custom error message")]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(1500, ErrorMessage = "No more than 1500 characters")]
        public virtual string Description { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (Title == Description)
        //        yield return new ValidationResult(
        //            "The provided description should be different from title.",
        //            new[] {"CourseCreationDto"}
        //        );
        //}
    }
}
