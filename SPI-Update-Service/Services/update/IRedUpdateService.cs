using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPI_Update_Service.model.update;
using SPI_Update_Service.model;
using SPI_Update_Service.model.model;
using SPI_Update_Service.model.delete;

namespace SPI_Update_Service.service.update
{
    public interface IRedUpdateService
    {
        /// <summary>
        /// Método para eliminar una llave
        /// </summary>
        Task<HttpResponseMessage> UpdateAccountAsync(string url, HeadersRq headers, UpdateAcctRq request);
        Task<HttpResponseMessage> UpdateKeyAsync(string url, HeadersRq headers, UpdateKeyPersonRq request);
    }
}
