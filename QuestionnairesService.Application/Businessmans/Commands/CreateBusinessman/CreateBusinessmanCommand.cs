using MediatR;
using Microsoft.AspNetCore.Http;
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
    public Stream? SkanContractRent { get; init; } = null!;

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
            byte[]? skanContractRentBytes = null;

            await using MemoryStream memoryStream = new MemoryStream();

            await command.SkanINN.CopyToAsync(memoryStream);
            skanINNBytes = memoryStream.ToArray();

            await command.SkanRegistrationNumber.CopyToAsync(memoryStream);
            skanRegistrationNumberBytes = memoryStream.ToArray();

            await command.SkanExtractFromTax.CopyToAsync(memoryStream);
            skanExtractFromTaxBytes = memoryStream.ToArray();

            if (command.SkanContractRent != null)
            {
                await command.SkanContractRent.CopyToAsync(memoryStream);
                skanContractRentBytes = memoryStream.ToArray();
            }
            var registrationDate = DateTime.Parse(command.BuisnessmenDto.RegistrationDate);
            registrationDate = DateTime.SpecifyKind(registrationDate, DateTimeKind.Utc);

            var newBuisnessman = isLimitedLiabilityCompany
                ? new Organization(
                    command.BuisnessmenDto.FullName!,
                    command.BuisnessmenDto.ShortName!,
                    command.BuisnessmenDto.INN,
                    skanINNBytes,
                    command.BuisnessmenDto.RegistrationNumber,
                    skanRegistrationNumberBytes,
                    registrationDate,
                    skanExtractFromTaxBytes,
                    skanContractRentBytes,
                    command.BuisnessmenDto.AvailabilityContract,
                    command.BuisnessmenDto.buisnessmanType)
                : new Organization(
                    command.BuisnessmenDto.INN,
                    skanINNBytes,
                    command.BuisnessmenDto.RegistrationNumber,
                    skanRegistrationNumberBytes,
                    registrationDate,
                    skanExtractFromTaxBytes,
                    skanContractRentBytes,
                    command.BuisnessmenDto.AvailabilityContract,
                    command.BuisnessmenDto.buisnessmanType);

            _questionnairesServiceDbContext.Organizations.Add(newBuisnessman);

            List<Bank> banks = new();

            command.BuisnessmenDto.Banks.ToList().ForEach(b =>
            {
                banks.Add(new Bank(
                    b.BankCode, 
                    b.BranchOfficeName, 
                    b.PaymentAccount, 
                    b.CorrespondentAccount, 
                    newBuisnessman));
            });

            _questionnairesServiceDbContext.Banks.AddRange(banks);

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

            if (string.IsNullOrEmpty(command.BuisnessmenDto.RegistrationDate))
            {
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Поле 'Дата регистрации' должно быть заполнено");
            }

            if (!DateTime.TryParse(command.BuisnessmenDto.RegistrationDate, out DateTime dateTime))
            {
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Невалидная 'Дата регистрации'");
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

            if (command.SkanContractRent == null && !command.BuisnessmenDto.AvailabilityContract)
            {
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Должен быть прикреплён 'Скан договора аренды помещения (офиса)' или стоять отметка об отсутствии договора аренды");
            }

            if (command.SkanContractRent != null && command.SkanContractRent.Length == 0)
            {
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Должен быть прикреплён 'Скан договора аренды помещения (офиса)'");
            }

            if (!CheckStreamSize(command.SkanINN))
            {
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "'Скан ИНН' не может быть больше 5 Мб");
            }

            if (!CheckStreamSize(command.SkanRegistrationNumber))
            {
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "'Скан ОГРНИП' не может быть больше 5 Мб");
            }

            if (!CheckStreamSize(command.SkanExtractFromTax))
            {
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "'Скан договора аренды помещения (офиса)' не может быть больше 5 Мб");
            }

            if (command.SkanContractRent != null && !CheckStreamSize(command.SkanContractRent))
            {
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "'Скан договора аренды помещения (офиса)' не может быть больше 5 Мб");
            }

            if (command.BuisnessmenDto.Banks.Any())
            {
                foreach (var bank in command.BuisnessmenDto.Banks)
                {
                    if (string.IsNullOrEmpty(bank.BankCode))
                    {
                        throw new BadRequestException(ErrorCodes.Common.BadRequest, "Поле 'БИК' должно быть заполнено");
                    }

                    if (string.IsNullOrEmpty(bank.BranchOfficeName))
                    {
                        throw new BadRequestException(ErrorCodes.Common.BadRequest, "Поле 'Название филиала банка' должно быть заполнено");
                    }

                    if (string.IsNullOrEmpty(bank.PaymentAccount))
                    {
                        throw new BadRequestException(ErrorCodes.Common.BadRequest, "Поле 'Расчётный счёт' должно быть заполнено");
                    }

                    if (string.IsNullOrEmpty(bank.CorrespondentAccount))
                    {
                        throw new BadRequestException(ErrorCodes.Common.BadRequest, "Поле 'Корреспонденский счёт' должно быть заполнено");
                    }
                }
            }
            else
            {
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Не были указанны 'Банковские реквизиты'");
            }
        }

        private bool CheckStreamSize(Stream stream)
        {
            long originalPosition = stream.Position;
            stream.Seek(0, SeekOrigin.End);
            long size = stream.Position;
            stream.Seek(originalPosition, SeekOrigin.Begin);
            return size <= 5242880;
        }
    }
}
