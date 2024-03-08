namespace base_user_management
{
    public abstract class AppException : ApplicationException
    {
        protected int _HttpResponseStatusCode = 500;
        public int HttpResponseStatusCode
        {
            get
            {
                return _HttpResponseStatusCode;
            }
        }

        public AppException(string message, Exception innerException = null) : base(message) { }
    }

    public class BadRequestException : AppException
    {
        public BadRequestException(string message) : base(message)
        {
            _HttpResponseStatusCode = 400;
        }
    }

    public class UnauthorizedException : AppException
    {
        public UnauthorizedException(string message) : base(message)
        {
            _HttpResponseStatusCode = 401;
        }
    }

    public class ForbiddenException : AppException
    {
        public ForbiddenException(string message) : base(message)
        {
            _HttpResponseStatusCode = 403;
        }
    }

    public class RequestTimeoutException : AppException
    {
        public RequestTimeoutException(string message) : base(message)
        {
            _HttpResponseStatusCode = 408;
        }
    }

    public class ServerErrorException : AppException
    {
        public ServerErrorException(string message, Exception innerException) : base(message, innerException)
        {
            _HttpResponseStatusCode = 500;
        }
    }
}