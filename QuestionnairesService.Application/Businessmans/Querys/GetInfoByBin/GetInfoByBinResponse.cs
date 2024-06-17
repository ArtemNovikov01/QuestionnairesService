namespace QuestionnairesService.Application.Businessmans.Querys.GetInfoByBin;
public class GetInfoByBinResponse
{
    /// <summary>
    ///     Название филиала банка
    /// </summary>
    public string NameBankBranch { get; set; }

    /// <summary>
    ///     Корреспондентский счет
    /// </summary>
    public string CorrespondentAccount { get; set; }
}
