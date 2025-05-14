using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.models.redeban;
using domain.models.redeban.response;
using SPI_Update_Service.domain.models.redeban;

namespace SPI_Update_Service.Proxy.interfaces
{
    public interface IRedUpdateService
    {
        /// <summary>
        /// Método para eliminar una llave
        /// </summary>
        Task<MsgInformationResponse> UpdateAccountAsync(string url, HeadersRq headers, UpdateAcctRq request);
    }
}
