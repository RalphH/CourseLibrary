using CourseLibrary.API.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Models
{
    [CourseTitleMustBeDifferentFromDescriptionAttribute]
    public class CourseForCreationDto 
    {
        [Required(ErrorMessage = "The course title should be filled in.")]
        [MaxLength(100, ErrorMessage = "The course title should be no more than 100 characters.")]
        public string Title { get; set; }

        [MaxLength(1500, ErrorMessage = "The course description should be no more than 1500 characters.")]
        public string Description { get; set; }        
    }
}
