using domain.constants;
using domain.models;
using domain.models.enrollment;
using domain.models.oAuth;
using domain.models.redeban;
using System.Runtime.Intrinsics.X86;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

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

        public void AddCreateHeaders(HttpClient request, HeadersRq headers, string token)
        {
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.CONTENT_TYPE, headers.ContentType);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.DATE, headers.Date);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.RBM_FROM, headers.RBMFrom);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.ACCEPT, headers.Accept);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.X_FORWARDED_FOR, headers.XForwardedFor);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.X_REQUEST_ID, Guid.NewGuid().ToString("D"));
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.ORIGIN, ConstantsEnum.ORIGIN);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.RQ_ID, random.NextInt64(100000000000, 999999999999).ToString());
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.AUTHORIZATION, ConstantsEnum.BEARER + " " + token.Trim());

            Console.WriteLine($"Headers conexión red: {request.DefaultRequestHeaders.ToString()}");
        }

        public void addOauthHeaders(HttpClient request)
        {
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.CONTENT_TYPE, ConstantsEnum.APPLICATION_URL_ENCODE);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.X_IBM_CLIENT_ID, ConstantsEnum.IBM_CLIENT_ID);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.X_IBM_CLIENT_SECRET, ConstantsEnum.IBM_Client_Secret);
        }

        public RqOAuth mapBodyOauth()
        {
            RqOAuth rqOauth = new RqOAuth();
            rqOauth.scopes = ConstantsEnum.SCOPES;
            rqOauth.grantType = ConstantsEnum.GRANTYPE;
            return rqOauth;
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

            //string newDate = body.effDtKey.effDtCreate.ToString();
          string newDate = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.fff");

            //string newDate = "2025-01-10T17:12:48.864";

            bodyRed.requestDateTime = newDate;

          Customer customer = new Customer();  
          customer.partySystemIdentifier = body.key.keyType;
          customer.partyIdentifier = body.key.keyId;
          customer.type = body.custInfo.custType;

          Commerce commerce = new Commerce();
          commerce.documentType = body.custInfo.custIdent.custIdentType;
          commerce.documentNumber = body.custInfo.custIdent.custIdentId;
          commerce.merchantId = body.custInfo.custIdent.mechantId;

          customer.commerce = commerce;
          bodyRed.customer = customer;

          Product product = new Product();
          Account account = new Account();
          
          account.BankId = ConstantsEnum.BANK_ID;
          account.TypeAccount = body.acctInfo.acctType;
          account.AccountNo = body.acctInfo.acctId;
          //account.ageAccount = DateTime.Now.ToString("YYYY-MM-DD");
          account.ageAccount = "2025-01-10";

          product.account = account;

          bodyRed.product = product;
          
          bodyRed.termsAndConditions = true;

          return bodyRed;


        }



    }

}
