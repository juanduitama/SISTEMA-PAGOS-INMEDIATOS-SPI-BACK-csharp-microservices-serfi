namespace domain.constants
{
    public static class ValidationEnums
    {

        public const string ACCOUNT_TYPE_CAHO = "CAHO";
        public const string ACCOUNT_TYPE_CCTE = "CCTE";
        public const string ACCOUNT_TYPE_DBMO = "DBMO";
        public const string ACCOUNT_TYPE_DORD = "DORD";
        public const string ACCOUNT_TYPE_DBMI = "DBMI";

        public const string ACCOUNT_ID = "^\\p{N}+$";

        public const string CUST_INFO_NAMES = "^\\p{L}+(?:\\s\\p{L}+)*$";
        public const string CUST_INFO_SIZE_40 = "40";
        public const string CUST_INFO_SIZE_140 = "140";

        public const string CUST_INFO_LEGAL_NAME_PN = "PERSON";
        public const string CUST_INFO_LEGAL_NAME_PJ = "COMMERCE";

        public const string CUST_IDENT_TYPE_CC = "CC";
        public const string CUST_IDENT_TYPE_CE = "CE";
        public const string CUST_IDENT_TYPE_NUIP = "NUIP";
        public const string CUST_IDENT_TYPE_PPT = "PPT";
        public const string CUST_IDENT_TYPE_NIT = "NIT";
        public const string CUST_IDENT_TYPE_PEP = "PEP";
        public const string CUST_IDENT_TYPE_PAS = "PAS";
        public const string CUST_IDENT_TYPE_TDI = "TDI";

        
        public const string IDENT_ID_SIZE = "18";
        public const string IDENT_ID = "^[a-zA-Z0-9]+$";
        
        public const string KEY_TYPE_IDENT = "USERIDENTIFICATION";
        public const string KEY_TYPE_CEL = "MSISDN";
        public const string KEY_TYPE_EMAIL = "EMAIL";
        public const string KEY_TYPE_ALIAS = "ALIAS";
        public const string KEY_TYPE_MERCH = "MERCHANTID";
        
        public const string KEY_ID_IDENT = "^[A-Za-z0-9]{6,18}$";
        public const string KEY_ID_CEL = "^3[0-9]{9}$";
        public const string KEY_ID_EMAIL= "^[a-zA-Z0-9._%+-]{1,30}@[a-zA-Z0-9.-]{1,61}$";
        public const string KEY_ID_ALIAS= "^[@][A-Za-z0-9]{5,19}$";
        public const string KEY_ID_MERCH=  @"^00\d{8}$";

        public const string KEY_ACTIVE_STATUS = "ACTIVA";

        public const string VAULT_NAME_RBM = "REDEBAN";

        public const string FLOW_SERVICES_CREATE = "creacionLinea";

        public const string DATE_FORMAT = "yyyy-MM-dd'T'HH:mm:ss.SSS'Z'";
    }
}
