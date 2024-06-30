using Microsoft.AspNetCore.Mvc;
using QuestionnairesService.Application.Services;

namespace QuestionnairesService.Application.Businessmans.Commands.CreateBusinessman.Models
{
    //[ModelBinder(BinderType = typeof(MetadataValueModelBinder))]
    public class BankDto
    {
        /// <summary>
        ///     БИК.
        /// </summary>
        public string BankCode { get; init; } = null!;

        /// <summary>
        ///     Название филиала банка.
        /// </summary>
        public string BranchOfficeName { get; init; } = null!;
        /// <summary>
        ///     Расчётный счёт.
        /// </summary>
        public string PaymentAccount { get; init; } = null!;

        /// <summary>
        ///     Корреспонденский счёт.
        /// </summary>
        public string CorrespondentAccount { get; init; } = null!;
    }
}
