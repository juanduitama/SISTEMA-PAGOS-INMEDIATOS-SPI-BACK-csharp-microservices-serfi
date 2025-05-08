using System.ComponentModel.DataAnnotations;
using domain.models;

namespace domain.models.enrollment
{
    public class UpdateAccountRq
    {

        public UpdateHeaders updateHeaders { get; set; }
        [Required]
        public ReqBPatchAccount reqBPatchAccount { get; set; }

    }
}
