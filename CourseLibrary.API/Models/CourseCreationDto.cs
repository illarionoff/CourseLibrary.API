using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CourseLibrary.API.ValidationAttributes;

namespace CourseLibrary.API.Models
{
    [CourseTitleMustBeDifferentFromDescription]
    public class CourseCreationDto  // : IValidatableObject
    {
        [Required(ErrorMessage = "Custom error message")] 
        [MaxLength(100)] 
        public string Title { get; set; }

        [MaxLength(1500)] 
        public string Description { get; set; }

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