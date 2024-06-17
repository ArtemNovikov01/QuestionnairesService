namespace QuestionnairesService.Application.Businessmans.Querys.GetInfoByInn;
public class GetInfoByInnResponse
{
    public string Inn { get; set; } = null!;

    /// <summary>
    ///     Полное имя.
    /// </summary>
    public string FullName { get; init; } = null!;

    /// <summary>
    ///     Короткое имя.
    /// </summary>
    public string ShortName { get; init; } = null!;

    /// <summary>
    ///     ОГРН.
    /// </summary>
    public string RegistrationNumber { get; init; } = null!;

    /// <summary>
    ///     Дата регистрации.
    /// </summary>
    public DateTime RegistrationDate { get; init; }
}
