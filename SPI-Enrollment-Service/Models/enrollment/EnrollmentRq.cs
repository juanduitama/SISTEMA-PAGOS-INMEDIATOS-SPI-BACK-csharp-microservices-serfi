using System.ComponentModel.DataAnnotations;

namespace Models.enrollment
{
    public class EnrollmentRq
    {
        [Required]
        public EnrollmentAccountHeaders enrollmenAccountHeaders { get; set; }
        [Required]
        public ReqBPostAccountRelationship reqBPostAccountRelationship { get; set; }

    }
}
