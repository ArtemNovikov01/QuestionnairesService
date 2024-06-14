namespace QuestionnairesService.Models.Entities;
public class BankRequisites 
{
    public int Id { get; private set; }

    /// <summary>
    ///     БИК.
    /// </summary>
    public string BankCode { get; private set; } = null!;

    /// <summary>
    ///     Название филиала банка.
    /// </summary>
    public string BranchOfficeName { get; private set; } = null!;
    /// <summary>
    ///     Расчётный счёт.
    /// </summary>
    public string PaymentAccount { get; private set; } = null!;

    /// <summary>
    ///     Корреспонденский счёт.
    /// </summary>
    public string CorrespondentAccount { get; private set; } = null!;
}
