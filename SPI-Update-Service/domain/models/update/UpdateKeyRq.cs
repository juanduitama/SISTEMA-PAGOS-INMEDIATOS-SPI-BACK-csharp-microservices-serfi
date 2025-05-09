using System.ComponentModel.DataAnnotations;
using domain.models;

namespace domain.models.enrollment
{
    public class UpdateKeyRq
    {
        
        public UpdateHeaders updateHeaders { get; set; }
        public ReqBPatchKey reqBPatchKey { get; set; }

    }
}
