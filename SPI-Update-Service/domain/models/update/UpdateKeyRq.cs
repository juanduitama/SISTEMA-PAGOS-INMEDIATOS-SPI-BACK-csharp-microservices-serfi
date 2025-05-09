using System.ComponentModel.DataAnnotations;
using domain.models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace domain.models.enrollment
{
    public class UpdateKeyRq
    {
        
        public UpdateHeaders updateHeaders { get; set; }
        public ReqBPatchKey reqBPatchKey { get; set; }

    }
}
