using System.ComponentModel.DataAnnotations;

namespace Models.enrollment
{
    public class EnrollmentRq
    {
        
        public EnrollmentAccountHeaders enrollmenAccountHeaders { get; set; }
        [Required]
        public ReqBPostAccountRelationship reqBPostAccountRelationship { get; set; }

    }
}
