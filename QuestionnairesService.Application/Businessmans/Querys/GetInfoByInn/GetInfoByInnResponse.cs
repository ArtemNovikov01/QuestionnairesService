using Newtonsoft.Json;

namespace QuestionnairesService.Application.Businessmans.Querys.GetInfoByInn;
public class GetInfoByInnResponse
{
    [JsonProperty("inn")]
    public long Inn { get; set; }

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
    public long RegistrationNumber { get; init; }

    /// <summary>
    ///     Дата регистрации.
    /// </summary>
    [JsonProperty("registrationDate")]
    public DateTime RegistrationDate { get; init; }
}
