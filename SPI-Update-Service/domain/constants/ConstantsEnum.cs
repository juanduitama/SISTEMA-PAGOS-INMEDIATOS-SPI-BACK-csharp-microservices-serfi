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
        public const string KEY_INQUIRY = "KeyInquiry";
        public const string ID_INQUIRY = "IdentInquiry";
        public const string MERCHANT_INQUIRY = "MerchantInquiry";
        public const string ENROLLMENT = "Enrollment";
        public const string DELETE = "Cancellation";
        public const string KEY_UPDATE = "UpdateKey";
        public const string ACCOUNT_UPDATE = "UpdateAccount";
        public const string IP_ORIGIN = "10.415.16.2";
        public const string RBM_FROM = "65a4a028-7b29-44d0-878c-03a479f8a23d";
        public const string INDEX_DEFINITIVE = "index_definitive";
        public const int TYPE_KEY_ID = 0;
        public const int TYPE_OLD_KEY_ID = 1;
        public const int TYPE_NEW_KEY_ID = 2;
        public const string IBM_CLIENT_ID = "54cfb091cdd1c1f30f9cb3423a28aebe";
        public const string IBM_Client_Secret = "c92296aaeeb1965330c077e1a8f73889";
        public const string BEARER = "Bearer";

        public const string SCOPES = "HUB";
        public const string GRANTYPE = "client_credentials";


        public const string BASE_URI_OAUTH = "https://gateway.qa.sandboxhubredeban.com/rbmcalidad/calidad/oauth2.0/oauth2/token";
        public const string BASE_URI_ACCOUNT = "https://gateway.qa.sandboxhubredeban.com/rbmcalidad/calidad/api/dir/v3.0.0/Directory/keytype/" + ConstantsEnum.KEY_TYPE_PATH + "/key/" + ConstantsEnum.KEY_VALUE_PATH;
        public const string BASE_URI_KEY = "https://gateway.qa.sandboxhubredeban.com/rbmcalidad/calidad/api/dir/v3.0.0/Directory/key/" + ConstantsEnum.ID_PATH;
        public const string KEY_VALUE_PATH = "{keyValue}";
        public const string KEY_TYPE_PATH = "{keyType}";
        public const string ID_PATH = "{ID}";


    }
}
