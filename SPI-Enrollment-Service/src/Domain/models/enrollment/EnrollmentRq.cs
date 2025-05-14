using System.ComponentModel.DataAnnotations;
using domain.models;

namespace domain.models.enrollment
{
    public class EnrollmentRq
    {
        
        public EnrollmentAccountHeaders enrollmenAccountHeaders { get; set; }
        [Required]
        public ReqBPostAccountRelationship reqBPostAccountRelationship { get; set; }

    }
}
