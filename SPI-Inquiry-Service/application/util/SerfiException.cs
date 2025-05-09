    public class SerfiException(string errorCode, string message, int httpCode) : Exception
    {
        public string errorCode { get; } = errorCode;
        public string message { get; } = message;
        public int httpCode { get; } = httpCode;
    }
