
using SPI_Enrollment_Service.constants;
using SPI_Enrollment_Service.model;
using SPI_Enrollment_Serviceconstants;
using System.Text.Json.Serialization.Metadata;
using System.Text.Json;
using Models.enrollment;
using SPI_Enrollment_Service.Models.redeban;
using SPI_Enrollment_Service.Models.enrollment;
using Models;

namespace SPI_Enrollment_Service.Mapper
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

        public void AddCreateHeaders(HttpClient request, HeadersRq headers)
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
        public HeadersRq MapHeadersFromRequest(EnrollmentAccountHeaders headersRq)
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
        
        public  EnrollmentRqRed MapBodyFromRequest(ReqBPostAccountRelationship body) 
        {
          EnrollmentRqRed bodyRed = new EnrollmentRqRed();

          bodyRed.requestDateTime = DateTime.Now.ToString("yyyy-MM-dd"); ;
          bodyRed.customer.partySystemIdentifier = body.key.keyType;
          bodyRed.customer.partyIdentifier = body.key.keyId;
          bodyRed.customer.type = body.custInfo.custType;
          bodyRed.customer.person.firstName = body.custInfo.firstName;
          bodyRed.customer.person.middleName = body.custInfo.secondName;
          bodyRed.customer.person.firstSurName = body.custInfo.lastName;
          bodyRed.customer.person.middleSurName = body.custInfo.secondLastName;
          bodyRed.customer.person.documentType = body.custInfo.custIdent.custIdentType;
          bodyRed.customer.person.documentNumber = body.custInfo.custIdent.custIdentId;
          bodyRed.customer.person.personContact.mobileNumber = body.custInfo.custContact.custMobileNumber;
          bodyRed.customer.person.personContact.email = body.custInfo.custContact.custEmail;
          bodyRed.product.Account.BankId = "0052";
          bodyRed.product.Account.TypeAccount = body.acctInfo.acctType;
          bodyRed.product.Account.AccountNo = body.acctInfo.acctId;
          bodyRed.product.Account.ageAccount = DateTime.Now.ToString("yyyy-MM-dd");
          bodyRed.termsAndConditions = true;

          return bodyRed;


        }



    }

}
