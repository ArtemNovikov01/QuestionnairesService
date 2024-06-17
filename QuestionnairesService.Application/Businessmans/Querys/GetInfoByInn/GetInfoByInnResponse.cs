using Newtonsoft.Json;

namespace QuestionnairesService.Application.Businessmans.Querys.GetInfoByInn;
public class GetInfoByInnResponse
{
    [JsonProperty("inn")]
    public string Inn { get; set; } = null!;

    /// <summary>
    ///     Полное имя.
    /// </summary>
    [JsonProperty("fullName")]
    public string FullName { get; init; } = null!;

    /// <summary>
    ///     Короткое имя.
    /// </summary>
    [JsonProperty("shortName")]
    public string ShortName { get; init; } = null!;

    /// <summary>
    ///     ОГРН.
    /// </summary>
    [JsonProperty("registrationNumber")]
    public string RegistrationNumber { get; init; } = null!;

    /// <summary>
    ///     Дата регистрации.
    /// </summary>
    [JsonProperty("registrationDate")]
    public DateTime RegistrationDate { get; init; }
}
