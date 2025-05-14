using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.constants
{
    /// <summary>
    /// ConstantsEnum define los valores de constantes utilizadas
    /// 
    /// Desarrollo 
    /// 
    /// Requerimiento:
    /// </summary>
    public static class ConstantsEnum
    {
        public const string PATCH_HTTP_METHOD = "PATCH";
        public const string APPLICATION_JSON = "application/json";
        public const string APPLICATION_URL_ENCODE = "application/x-www-form-urlencoded";
        public const string TYPE_PERSON = "PERSON";
        public const string ORIGIN = "origin";
        public const string TYPE_COMMERCE = "COMMERCE";
        public const string OAUTH_TOKEN = "TOKEN";
        public const string BEARER = "Bearer";
        public const string KEY_INQUIRY = "KeyInquiry";
        public const string ID_INQUIRY = "IdentInquiry";
        public const string MERCHANT_INQUIRY = "MerchantInquiry";
        public const string ENROLLMENT = "Enrollment";
        public const string DELETE = "Cancellation";
        public const string KEY_UPDATE = "UpdateKey";
        public const string ACCOUNT_UPDATE = "UpdateAccount";
        public const string IP_ORIGIN = "10.415.16.2";
        public const string RBM_FROM = "d0573cdf-112f-4bda-ab35-d25363cf4092";
        public const string INDEX_DEFINITIVE = "index_definitive";
        public const string BANK_ID = "0423";
        public const string IBM_CLIENT_ID = "54cfb091cdd1c1f30f9cb3423a28aebe";
        public const string IBM_Client_Secret = "c92296aaeeb1965330c077e1a8f73889";

        public const string SCOPES = "HUB";
        public const string GRANTYPE = "client_credentials";



        public const string BASE_URI = "https://gateway.qa.sandboxhubredeban.com/rbmcalidad/calidad/api/dir/v3.0.0/Directory/key";
        public const string BASE_URI_OAUTH = "https://gateway.qa.sandboxhubredeban.com/rbmcalidad/calidad/oauth2.0/oauth2/token";


    }
}
