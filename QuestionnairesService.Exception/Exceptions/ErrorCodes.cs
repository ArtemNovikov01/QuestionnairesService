namespace QuestionnairesService.Exceptions.Common.Exceptions;

public static class ErrorCodes
{
    private const string Prefix = "ERR";
    
    public static class Common
    {
        public const string BadRequest = Prefix + "_BAD_REQUEST";
        public const string NotFound = Prefix + "_NOT_FOUND";
    }
}