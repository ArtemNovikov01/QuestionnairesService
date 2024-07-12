namespace QuestionnairesService.Exceptions.Common.Exceptions;

public class BadRequestException : BaseException
{
    public BadRequestException(string errorCode, string message) : base(errorCode, message)
    {
    }
}