using Newtonsoft.Json;

namespace QuestionnairesService.Application.Businessmans.Querys.GetInfoByBin;
public class GetInfoByBinResponse
{
    /// <summary>
    ///     Название филиала банка
    /// </summary>
    [JsonProperty("bin")]
    public long Bin { get; init; }

    /// <summary>
    ///     Название филиала банка
    /// </summary>
    [JsonProperty("nameBankBranch")]
    public string NameBankBranch { get; init; } = null!;

    /// <summary>
    ///     Корреспондентский счет
    /// </summary>
    [JsonProperty("correspondentAccount")]
    public string CorrespondentAccount { get; init; } = null!;
}
