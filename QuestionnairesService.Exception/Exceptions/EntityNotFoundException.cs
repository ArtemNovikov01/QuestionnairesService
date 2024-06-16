using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace QuestionnairesService.Exceptions.Common.Exceptions;

public class EntityNotFoundException : BaseException
{
    private EntityNotFoundException(string message) : base(ErrorCodes.Common.NotFound, message)
    {
    }

    [StringFormatMethod("messageTemplate")]
    public static void ThrowIfNull<T>([System.Diagnostics.CodeAnalysis.NotNull] T? entity, string messageTemplate,
        params object[] args)
    {
        if (entity is null)
        {
            Throw(messageTemplate, args);
        }
    }

    [StringFormatMethod("messageTemplate")]
    public static void ThrowIfAny<T>(IEnumerable<T> entities, string messageTemplate, params object[] args)
    {
        if (entities.Any())
        {
            Throw(messageTemplate, args);
        }
    }

    
    [DoesNotReturn]
    [StringFormatMethod("messageTemplate")]
    public static void Throw(string messageTemplate, params object[] args)
    {
        throw new EntityNotFoundException(string.Format(messageTemplate, args));
    }
}