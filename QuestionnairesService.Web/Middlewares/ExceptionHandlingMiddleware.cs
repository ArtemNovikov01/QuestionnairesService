using QuestionnairesService.Exceptions.Common.Exceptions;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (EntityNotFoundException e)
        {
            context.Response.Clear();
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsJsonAsync(Error(e));
        }
        catch (BadRequestException e)
        {
            context.Response.Clear();
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(Error(e));
        }
    }

    private static object Error(BaseException e)
    {
        return new
        {
            ErrorCode = e.ErrorCode,
            Message = e.Message
        };
    }
}
