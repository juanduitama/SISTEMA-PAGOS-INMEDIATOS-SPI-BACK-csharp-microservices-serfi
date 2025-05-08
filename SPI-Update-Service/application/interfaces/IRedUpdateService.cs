using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.models.redeban;
using domain.models.redeban.response;
using SPI_Update_Service.domain.models.redeban;

namespace SPI_Update_Service.service.update
{
    public interface IRedUpdateService
    {
        /// <summary>
        /// Método para eliminar una llave
        /// </summary>
        Task<MessageInformation> UpdateAccountAsync(string url, HeadersRq headers, UpdateAcctRq request);
        Task<MessageInformation> UpdateKeyAsync(string url, HeadersRq headers, UpdateKeyPersonRq request);
    }
}
