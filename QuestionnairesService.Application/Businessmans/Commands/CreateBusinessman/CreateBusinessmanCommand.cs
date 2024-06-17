using MediatR;
using QuestionnairesService.Application.Businessmans.Commands.CreateBusinessman.Models;
using QuestionnairesService.Application.Services;
using QuestionnairesService.Exceptions.Common.Exceptions;
using QuestionnairesService.Models.Entities;
using QuestionnairesService.Models.Enums;

namespace QuestionnairesService.Application.Businessmans.Commands.CreateBusinessman;
public record CreateBusinessmanCommand: IRequest<CreateBusinessmanResponse>
{
    public BuisnessmenDto BuisnessmenDto { get; init; } = null!;

    /// <summary>
    ///     Скан ИНН.
    /// </summary>
    public Stream SkanINN { get; init; } = null!;

    /// <summary>
    ///     Скан ОГРНИП.
    /// </summary>
    public Stream SkanRegistrationNumber { get; init; } = null!;

    /// <summary>
    ///     Скан выписки из ЕГРИП
    /// </summary>
    public Stream SkanExtractFromTax { get; init; } = null!;
    /// <summary>
    ///     Скан договора аренды помещения (офиса).
    /// </summary>
    public Stream SkanContractRent { get; init; } = null!;

    public sealed class CreateArticleTagCommandHandler : IRequestHandler<CreateBusinessmanCommand, CreateBusinessmanResponse>
    {
        private readonly IQuestionnairesServiceDbContext _questionnairesServiceDbContext;

        public CreateArticleTagCommandHandler(IQuestionnairesServiceDbContext questionnairesServiceDbContext)
        {
            _questionnairesServiceDbContext = questionnairesServiceDbContext;
        }

        public async Task<CreateBusinessmanResponse> Handle(CreateBusinessmanCommand command, CancellationToken cancellationToken)
        {
            bool isLimitedLiabilityCompany = command.BuisnessmenDto.buisnessmanType == BuisnessmanType.LimitedLiabilityCompany;
            ValidateRequestAndThrow(isLimitedLiabilityCompany, command);

            byte[] skanINNBytes;
            byte[] skanRegistrationNumberBytes;
            byte[] skanExtractFromTaxBytes;
            byte[] skanContractRentBytes;

            using (var memoryStream = new MemoryStream())
            {
                await command.SkanINN.CopyToAsync(memoryStream);
                skanINNBytes = memoryStream.ToArray();
            }

            using (var memoryStream = new MemoryStream())
            {
                await command.SkanRegistrationNumber.CopyToAsync(memoryStream);
                skanRegistrationNumberBytes = memoryStream.ToArray();
            }

            using (var memoryStream = new MemoryStream())
            {
                await command.SkanExtractFromTax.CopyToAsync(memoryStream);
                skanExtractFromTaxBytes = memoryStream.ToArray();
            }

            using (var memoryStream = new MemoryStream())
            {
                await command.SkanContractRent.CopyToAsync(memoryStream);
                skanContractRentBytes = memoryStream.ToArray();
            }

            var newBuisnessman = isLimitedLiabilityCompany
                ? new LimitedLiabilityCompany(
                command.BuisnessmenDto.FullName,
                command.BuisnessmenDto.ShortName,
                command.BuisnessmenDto.INN,
                skanINNBytes,
                command.BuisnessmenDto.RegistrationNumber,
                skanRegistrationNumberBytes,
                skanExtractFromTaxBytes,
                skanContractRentBytes,
                command.BuisnessmenDto.AvailabilityContract,
                command.BuisnessmenDto.buisnessmanType,
                command.BuisnessmenDto.BankCode,
                command.BuisnessmenDto.BranchOfficeName,
                command.BuisnessmenDto.PaymentAccount,
                command.BuisnessmenDto.CorrespondentAccount)
                : new LimitedLiabilityCompany(
                command.BuisnessmenDto.INN,
                skanINNBytes,
                command.BuisnessmenDto.RegistrationNumber,
                skanRegistrationNumberBytes,
                skanExtractFromTaxBytes,
                skanContractRentBytes,
                command.BuisnessmenDto.AvailabilityContract,
                command.BuisnessmenDto.buisnessmanType,
                command.BuisnessmenDto.BankCode,
                command.BuisnessmenDto.BranchOfficeName,
                command.BuisnessmenDto.PaymentAccount,
                command.BuisnessmenDto.CorrespondentAccount);

            _questionnairesServiceDbContext.LimitedLiabilityCompanies.Add(newBuisnessman);

            await _questionnairesServiceDbContext.SaveChangesAsync(cancellationToken);

            return new CreateBusinessmanResponse()
            {
                BuisnessmanId = newBuisnessman.Id
            };
        }

        private void ValidateRequestAndThrow(bool isLimitedLiabilityCompany, CreateBusinessmanCommand command)
        {
            if (command.BuisnessmenDto.buisnessmanType <=0)
            {
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Не выбран тип предпринимательства");
            }

            if(isLimitedLiabilityCompany)
            {
                if (string.IsNullOrEmpty(command.BuisnessmenDto.FullName))
                {
                    throw new BadRequestException(ErrorCodes.Common.BadRequest, "Поле 'Наименование полное' должно быть заполнено");
                }

                if (string.IsNullOrEmpty(command.BuisnessmenDto.ShortName))
                {
                    throw new BadRequestException(ErrorCodes.Common.BadRequest, "Поле 'Наименование сокращённое' должно быть заполнено");
                }
            }

            if (string.IsNullOrEmpty(command.BuisnessmenDto.INN))
            {
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Поле 'ИНН' должно быть заполнено");
            }

            if (string.IsNullOrEmpty(command.BuisnessmenDto.RegistrationNumber))
            {
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Поле 'ОГРНИП' должно быть заполнено");
            }

            if (string.IsNullOrEmpty(command.BuisnessmenDto.RegistrationNumber))
            {
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Поле 'ОГРНИП' должно быть заполнено");
            }

            if (command.SkanINN.Length == 0)
            {
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Должен быть прикреплён 'Скан ИНН'");
            }

            if (command.SkanRegistrationNumber.Length == 0)
            {
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Должен быть прикреплён 'Скан ОГРНИП'");
            }

            if (command.SkanExtractFromTax.Length == 0)
            {
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Должен быть прикреплён 'Скан выписки из ЕГРИП'");
            }

            if (command.SkanContractRent.Length == 0)
            {
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Должен быть прикреплён 'Скан договора аренды помещения (офиса)'");
            }

            if (command.BuisnessmenDto != null)
            {
                if (string.IsNullOrEmpty(command.BuisnessmenDto.BankCode))
                {
                    throw new BadRequestException(ErrorCodes.Common.BadRequest, "Поле 'БИК' должно быть заполнено");
                }

                if (string.IsNullOrEmpty(command.BuisnessmenDto.BranchOfficeName))
                {
                    throw new BadRequestException(ErrorCodes.Common.BadRequest, "Поле 'Название филиала банка' должно быть заполнено");
                }

                if (string.IsNullOrEmpty(command.BuisnessmenDto.PaymentAccount))
                {
                    throw new BadRequestException(ErrorCodes.Common.BadRequest, "Поле 'Расчётный счёт' должно быть заполнено");
                }

                if (string.IsNullOrEmpty(command.BuisnessmenDto.CorrespondentAccount))
                {
                    throw new BadRequestException(ErrorCodes.Common.BadRequest, "Поле 'Корреспонденский счёт' должно быть заполнено");
                }
            }
            else
            {
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Не были указанны 'Банковские реквизиты'");
            }
        }
    }
}
