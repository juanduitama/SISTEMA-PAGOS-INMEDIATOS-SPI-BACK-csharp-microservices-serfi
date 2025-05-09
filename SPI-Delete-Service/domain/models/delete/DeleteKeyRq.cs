using System.Text.Json.Serialization;
using domain.models.enrollment;

namespace SPI_Delete_Service.domain.models.delete
{
    public class DeleteKeyRq
    {
        public DeleteHeaders deleteHeaders { get; set; }

        public ReqBPutKey reqBPutKey { get; set; }
    }
}
