using System.Text.Json.Serialization.Metadata;
using System.Text.Json;
using domain.constants;
using domain.models;
using domain.models.enrollment;
using domain.models.redeban;
using SPI_Update_Service.domain.models.redeban;
using domain.models.openSearchModel;
using application.util;

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

        public void AddUpdateHeaders(HttpClient request, HeadersRq headers)
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

        }

        //Cabeceras de OS a Redeban
        public HeadersRq MapHeadersFromRequest(InquiryHeaders headersRq)
        {
            HeadersRq headersRed = new HeadersRq();

            string newDate = headersRq.timeStamps.Replace("Z", "");
            
            headersRed.ContentType = ConstantsEnum.APPLICATION_JSON;
            headersRed.Date = newDate;
            headersRed.RBMFrom = ConstantsEnum.RBM_FROM;
            headersRed.Accept = ConstantsEnum.APPLICATION_JSON;
            headersRed.XForwardedFor = ConstantsEnum.IP_ORIGIN;
            headersRed.XRequestId = headersRq.uuId;
            headersRed.Origin = RedHeadersEnum.ORIGIN;
            headersRed.RBMUserDate = DateTime.Now.ToString("YYYY-MM-DDThh:mm:ss.SSS");
            headersRed.XTransacctionRequest = false;

            return headersRed;

        }
        
        public  UpdateKeyPersonRq MapBodyKeyFromRequest(UpdateKeyRq request) 
        {
          
          UpdateKeyPersonRq bodyRed = new UpdateKeyPersonRq();

          //string newDate = request.updateHeaders.timeStamps.ToString().Replace("Z", "");

          bodyRed.requestDateTime = DateTime.Now.ToString("YYYY-MM-DDThh:mm:ss.SSS");
          bodyRed.partySystemIdentifier = request.reqBPatchKey.key.oldKeyType;
          bodyRed.partyIdentifier = request.reqBPatchKey.key.oldKeyId;
          bodyRed.newPartySystemIdentifier = request.reqBPatchKey.key.newKeyType;
          bodyRed.newPartyIdentifier = request.reqBPatchKey.key.newKeyId;


           return bodyRed;


        }

        public UpdateAcctRq MapBodyAccountFromRequest(ReqBPatchAccount reqBPatchAccount, OSDefinitive osOldDefinitive)
        {
            UpdateAcctRq bodyRed = new UpdateAcctRq();

            
            bodyRed.requestDateTime = DateTime.Now.ToString("YYYY-MM-DDThh:mm:ss.SSS");

            Console.WriteLine(DateTime.Now.ToString("YYYY-MM-DDThh:mm:ss.SSS"));

            Customer customer = new Customer();
            customer.type = osOldDefinitive.custInfoOS.custType;            


            Person person = new Person();

            person.firstName = osOldDefinitive.custInfoOS.firstName;
            person.middleName = osOldDefinitive.custInfoOS.secondName;
            person.firstSurName = osOldDefinitive.custInfoOS.lastName;
            person.middleSurName = osOldDefinitive.custInfoOS.secondLastName;

            
            person.documentType = osOldDefinitive.custInfoOS.custIdent.custIdentType;
            person.documentNumber = osOldDefinitive.custInfoOS.custIdent.custIdentId;

            PersonContact personContact = new PersonContact();
            personContact.mobileNumber = osOldDefinitive.custInfoOS.custContact.custMobileNumber;

            person.personContact = personContact;

            customer.person = person;
            bodyRed.customer = customer;

            Account account = new Account();

            account.typeAccount = reqBPatchAccount.acctInfo.newAcctType != null ? reqBPatchAccount.acctInfo.newAcctType : osOldDefinitive.acctInfo.acctType;
            account.accountNo = reqBPatchAccount.acctInfo.newAcctId != null ? reqBPatchAccount.acctInfo.newAcctId : osOldDefinitive.acctInfo.acctId;

            Product product = new Product();
            
            product.account = account;
            
            bodyRed.product = product;


            return bodyRed;
        }



    }

}
