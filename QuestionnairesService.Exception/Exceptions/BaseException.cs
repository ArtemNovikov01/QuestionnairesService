namespace QuestionnairesService.Exceptions.Common.Exceptions;

public class BaseException : Exception
{
    public string ErrorCode { get; private set; }
    
    public BaseException(string errorCode, string message) : base(message)
    {
        ErrorCode = errorCode;
    }

    public BaseException(string errorCode, string message, Exception? innerException) : base(message, innerException)
    {
        ErrorCode = errorCode;
    }
}