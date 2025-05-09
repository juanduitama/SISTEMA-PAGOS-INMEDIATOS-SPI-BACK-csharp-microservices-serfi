using System.Text.Json.Serialization.Metadata;
using System.Text.Json;
using domain.constants;
using domain.models;
using domain.models.enrollment;
using domain.models.redeban;
using SPI_Delete_Service.domain.models.delete;
using SPI_Delete_Service.domain.models.redeban;
using domain.models.openSearchModel;

namespace application.mapper
{
    /// <summary>
    /// Utilidad para manejar encabezados HTTP
    /// </summary>
    public class RedRqMapper
    {

        private static readonly Random random = new Random();

        public RedRqMapper()
        {

        }

        public void AddDeleteHeaders(HttpClient request, HeadersRq headers)
        {
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.CONTENT_TYPE, headers.ContentType);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.DATE, headers.Date);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.RBM_FROM, headers.RBMFrom);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.ACCEPT, headers.Accept);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.X_FORWARDED_FOR, headers.XForwardedFor);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.X_REQUEST_ID, Guid.NewGuid().ToString("D"));
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.ORIGIN, ConstantsEnum.ORIGIN);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.CHANNEL, headers.Channel);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.RQ_ID, random.NextInt64(100000000000, 999999999999).ToString());
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.RBM_USER_DATE, headers.RBMUserDate);
            Console.WriteLine("Estos son los headers para http");

            Console.WriteLine(request.DefaultRequestHeaders.ToString());
        }

        //Cabeceras de OS a Redeban
        public HeadersRq MapHeadersFromRequest(DeleteHeaders headersRq)
        {
            HeadersRq headersRed = new HeadersRq();

            string newDate = headersRq.timeStamps.Replace("Z", "");
            
            headersRed.Date = newDate;
            headersRed.ContentType = ConstantsEnum.APPLICATION_JSON;
            headersRed.Accept = ConstantsEnum.APPLICATION_JSON;
            headersRed.Origin = RedHeadersEnum.ORIGIN;
            headersRed.XForwardedFor = ConstantsEnum.IP_ORIGIN;
            headersRed.XRequestId = headersRq.uuId;
            headersRed.RBMFrom = ConstantsEnum.RBM_FROM;

            return headersRed;

        }
        
        public  DeleteRq MapBodyFromRequest(ReqBPutKey body, OSDefinitive osEntity) 
        {
            DeleteRq bodyRed = new DeleteRq();

          string newDate = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.SSS");

          bodyRed.requestDateTime = newDate;
          bodyRed.keyStatus = body.key.keyStatus;
          bodyRed.documentType = osEntity.custInfoOS.custIdent.custIdentType;
          bodyRed.documentNumber = osEntity.custInfoOS.custIdent.custIdentId;

          return bodyRed;


        }



    }

}
