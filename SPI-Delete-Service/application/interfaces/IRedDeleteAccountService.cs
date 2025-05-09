using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPI_Delete_Service.domain.models.redeban;
using domain.models.redeban;
using domain.models.redeban.response;

namespace SPI_Delete_Service.application.interfaces
{
    public interface IRedDeleteAccountService
    {
        /// <summary>
        /// Método para eliminar una llave
        /// </summary>
        Task<MessageInformation> DeleteKeyAsync(string url, HeadersRq headers, DeleteRq deleteRq);
    }
}
