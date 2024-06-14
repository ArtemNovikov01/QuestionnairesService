namespace QuestionnairesService.Models.Entities;
public class LimitedLiabilityCompany
{
    public int Id { get; private set; }

    /// <summary>
    ///     Наименование полное.
    /// </summary>
    public string FullName { get; private set; } = null!;

    /// <summary>
    ///     Наименование сокращённое.
    /// </summary>
    public string ShortName { get; private set; } = null!;

    /// <summary>
    ///  ИНН.
    /// </summary>
    public string INN { get; private set; } = null!;

    /// <summary>
    ///     Скан ИНН.
    /// </summary>
    public byte[] SkanINN { get; private set; } = null!;

    /// <summary>
    ///     ОГРНИП.
    /// </summary>
    public string RegistrationNumber { get; private set; } = null!;

    /// <summary>
    ///     Скан ОГРНИП.
    /// </summary>
    public byte[] SkanRegistrationNumber { get; private set; } = null!;

    /// <summary>
    ///     Дата регистрации.
    /// </summary>
    public DateTime DateRegistration { get; private set; } = DateTime.Now;

    /// <summary>
    ///     Скан выписки из ЕГРИП
    /// </summary>
    public byte[] SkanExtractFromTax { get; private set; } = null!;
    /// <summary>
    ///     Скан договора аренды помещения (офиса).
    /// </summary>
    public byte[] SkanContractRent { get; private set; } = null!;

    /// <summary>
    ///     Наличие договора.
    /// </summary>
    public bool AvailabilityContract { get; private set; }

    /// <summary>
    ///     Банковские реквизиты
    /// </summary>
    public int BankRequisitesId { get; private set; }
    public BankRequisites BankRequisites { get; private set; } = null!;

    #region Constructors
    public LimitedLiabilityCompany() { }
    public LimitedLiabilityCompany(
        string fullName, 
        string shortName, 
        string inn, 
        byte[] skanInn, 
        string registrationNumber, 
        byte[] skanRegistrationNumber,
        byte[] skanExtractFromTax,
        byte[] skanContractRent,
        bool availabilityContract)
    {
        FullName = fullName;
        ShortName = shortName;
        INN = inn;
        SkanINN = skanInn;
        RegistrationNumber = registrationNumber;
        SkanRegistrationNumber = skanRegistrationNumber;
        SkanExtractFromTax = skanExtractFromTax;
        SkanContractRent = skanContractRent;
        AvailabilityContract = availabilityContract;
    }
    #endregion
}
