using QuestionnairesService.Models.Enums;

namespace QuestionnairesService.Models.Entities;
public class Organization
{
    public int Id { get; private set; }

    public string? FullName { get; private set; }
    
    public string? ShortName { get; private set; }

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

    public IList<Bank>? Banks { get; private set; }

    #region Constructors
    public Organization() { }

    public Organization( 
        string inn, 
        byte[] skanInn, 
        string registrationNumber, 
        byte[] skanRegistrationNumber,
        byte[] skanExtractFromTax,
        byte[] skanContractRent,
        bool availabilityContract,
        BuisnessmanType buisnessmanType)
    {
        INN = inn;
        SkanINN = skanInn;
        RegistrationNumber = registrationNumber;
        SkanRegistrationNumber = skanRegistrationNumber;
        SkanExtractFromTax = skanExtractFromTax;
        SkanContractRent = skanContractRent;
        AvailabilityContract = availabilityContract;
        BuisnessmanType = buisnessmanType;
    }

    public Organization(
        string fullName,
        string shortName,
        string inn,
        byte[] skanInn,
        string registrationNumber,
        byte[] skanRegistrationNumber,
        byte[] skanExtractFromTax,
        byte[] skanContractRent,
        bool availabilityContract,
        BuisnessmanType buisnessmanType)
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
    }
    #endregion
}
