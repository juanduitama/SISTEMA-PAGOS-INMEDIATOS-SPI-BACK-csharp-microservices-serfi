using System.ComponentModel.DataAnnotations;
using domain.models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace domain.models.enrollment
{
    public class UpdateAccountRq
    {

        public UpdateHeaders updateHeaders { get; set; }
        [ValidateNever]
        public ReqBPatchAccount reqBPatchAccount { get; set; }

    }
}
