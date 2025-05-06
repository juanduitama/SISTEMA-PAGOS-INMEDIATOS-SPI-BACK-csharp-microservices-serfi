using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPI_Delete_Serviceconstants
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

        public const string BASE_URI = "https://10.130.1.74:5067/FederateDirectoryIntegrationRBM_SPI/rbmcalidad/calidad/api/dir/v3.0.0/Directory/";

    }
}
