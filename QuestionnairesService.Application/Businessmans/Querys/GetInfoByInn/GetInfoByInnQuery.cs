﻿using MediatR;
using Newtonsoft.Json;
using QuestionnairesService.Exceptions.Common.Exceptions;
using QuestionnairesService.Exceptions.Resources;

namespace QuestionnairesService.Application.Businessmans.Querys.GetInfoByInn;
public record GetInfoByInnQuery : IRequest<GetInfoByInnResponse>
{
    public long Inn { get; init; }
    public sealed class GetInfoByInnQueryHandler : IRequestHandler<GetInfoByInnQuery, GetInfoByInnResponse>
    {

        private readonly string _jsonFilePath = "./InitData/LimitedLiabilityCompanies.json";

        public GetInfoByInnQueryHandler(){}

        public async Task<GetInfoByInnResponse> Handle(GetInfoByInnQuery query, CancellationToken cancellationToken)
        {
            ValidateRequestAndThrow(query);

            try
            {
                using StreamReader streamReader = new StreamReader(_jsonFilePath);

                var json = await streamReader.ReadToEndAsync();
                var jsonObject = JsonConvert.DeserializeObject<CompanyDto>(json);

                if (jsonObject is not null)
                {
                    var companyInfo = jsonObject.CompanyInfo.FirstOrDefault(c => c.Inn == query.Inn);

                    EntityNotFoundException.ThrowIfNull(companyInfo, CompanyInfoErrorString.CompanyInfoNotFoundTemplate, query.Inn);
                    return companyInfo;
                }
                else
                {
                    throw new BadRequestException(ErrorCodes.Common.BadRequest, "Список компаний пуст.");
                }
            }
            catch (DirectoryNotFoundException)
            {
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Указан неверный путь");
            }
            catch (Exception exception)
            {
                throw new BadRequestException(ErrorCodes.Common.BadRequest, exception.Message);
            }
            
        }

        private void ValidateRequestAndThrow(GetInfoByInnQuery query)
        {
            if (query.Inn == 0)
            {
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Поле 'ИНН' должно быть заполнено.");
            }
            if (query.Inn.ToString().Length != 10)
            {
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "ИНН должно состоять из 10 цифр.");
            }
        }

        private class CompanyDto
        {
            [JsonProperty("limitedLiabilityCompanies")]
            public List<GetInfoByInnResponse> CompanyInfo { get; set; } = null!;
        }
    }
}
