namespace domain.constants
{
    public static class ValidationEnums
    {

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
        public const string KEY_BLOCK_STATUS = "BLOQUEADO";
        public const string KEY_ON_HOLD_STATUS = "ON_HOLD";
        public const string KEY_CANCEL_STATUS = "CANCELADA";

        public const string VAULT_NAME_RBM = "REDEBAN";

        public const string FLOW_SERVICES_CREATE = "creacionLinea";

        public const string DATE_FORMAT = "yyyy-MM-dd'T'HH:mm:ss.SSS'Z'";
    }
}
