using QuestionnairesService.Models.Enums;

namespace QuestionnairesService.Models.Entities;
public class LimitedLiabilityCompany
{
    public int Id { get; private set; }

    public string FullName { get; private set; }
    
    public string ShortName { get; private set; }
    public string BankCode { get; private set; }
    public string BranchOfficeName { get; private set; }
    public string CorrespondentAccount { get; private set; }

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
    ///     Скан ОГРНИП.или ОГРН
    /// </summary>
    public byte[] SkanRegistrationNumber { get; private set; } = null!;

    /// <summary>
    ///     Дата регистрации.
    /// </summary>
    public DateTime DateRegistration { get; private set; } = DateTime.UtcNow;

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

    public BuisnessmanType BuisnessmanType { get; private set; }
    
    /// <summary>
    ///     Расчётный счёт.
    /// </summary>
    public string PaymentAccount { get; private set; } = null!;

    #region Constructors
    public LimitedLiabilityCompany() { }

    public LimitedLiabilityCompany( 
        string inn, 
        byte[] skanInn, 
        string registrationNumber, 
        byte[] skanRegistrationNumber,
        byte[] skanExtractFromTax,
        byte[] skanContractRent,
        bool availabilityContract,
        BuisnessmanType buisnessmanType,
        string bankCode,
        string branchOfficeName,
        string paymentAccount,
        string correspondentAccount)
    {
        INN = inn;
        SkanINN = skanInn;
        RegistrationNumber = registrationNumber;
        SkanRegistrationNumber = skanRegistrationNumber;
        SkanExtractFromTax = skanExtractFromTax;
        SkanContractRent = skanContractRent;
        AvailabilityContract = availabilityContract;
        BuisnessmanType = buisnessmanType;
        BankCode = bankCode;
        BranchOfficeName = branchOfficeName;
        PaymentAccount = paymentAccount;
        CorrespondentAccount = correspondentAccount;
    }

    public LimitedLiabilityCompany(
        string fullName,
        string shortName,
        string inn,
        byte[] skanInn,
        string registrationNumber,
        byte[] skanRegistrationNumber,
        byte[] skanExtractFromTax,
        byte[] skanContractRent,
        bool availabilityContract,
        BuisnessmanType buisnessmanType,
        string bankCode,
        string branchOfficeName,
        string paymentAccount,
        string correspondentAccount)
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
        BuisnessmanType = buisnessmanType;
        BankCode = bankCode;
        BranchOfficeName = branchOfficeName;
        PaymentAccount = paymentAccount;
        CorrespondentAccount = correspondentAccount;

    }
    #endregion
}
