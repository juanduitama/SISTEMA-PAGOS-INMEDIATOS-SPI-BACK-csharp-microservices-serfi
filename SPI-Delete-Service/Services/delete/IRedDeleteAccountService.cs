using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPI_Delete_Service.model.delete;
using SPI_Delete_Service.model;
using SPI_Delete_Service.model.enrollment;
using SPI_Delete_Service.model.model;

namespace SPI_Delete_Service.service.service.delete
{
    public interface IRedDeleteAccountService
    {
        /// <summary>
        /// Método para eliminar una llave
        /// </summary>
        Task<HttpResponseMessage> DeleteKeyAsync(string url, HeadersRq headers, DeleteRq deleteRq);
    }
}
