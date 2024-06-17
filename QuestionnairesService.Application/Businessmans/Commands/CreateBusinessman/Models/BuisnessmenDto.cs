using QuestionnairesService.Models.Enums;

namespace QuestionnairesService.Application.Businessmans.Commands.CreateBusinessman.Models
{
    public class BuisnessmenDto
    {
        public BuisnessmanType buisnessmanType { get; init; }
        /// <summary>
        ///     Наименование полное.
        /// </summary>
        public string FullName { get; init; } = null!;

        /// <summary>
        ///     Наименование сокращённое.
        /// </summary>
        public string ShortName { get; init; } = null!;

        /// <summary>
        ///  ИНН.
        /// </summary>
        public string INN { get; init; } = null!;

        /// <summary>
        ///     ОГРНИП.
        /// </summary>
        public string RegistrationNumber { get; init; } = null!;

        /// <summary>
        ///     Наличие договора.
        /// </summary>
        public bool AvailabilityContract { get; init; }
    }
}
