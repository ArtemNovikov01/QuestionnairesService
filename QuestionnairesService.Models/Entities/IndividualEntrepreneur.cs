using System.Security.Cryptography.X509Certificates;

namespace QuestionnairesService.Models.Entities;
public class IndividualEntrepreneur
{
    public int Id { get; private set; }

    /// <summary>
    ///     ИНН.
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
    public IndividualEntrepreneur() { }
    public IndividualEntrepreneur(
        string inn,
        byte[] skanInn,
        string registrationNumber,
        byte[] skanRegistrationNumber,
        byte[] skanExtractFromTax,
        byte[] skanContractRent,
        bool availabilityContract)
    {
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
