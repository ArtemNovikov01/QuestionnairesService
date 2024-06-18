using MediatR;
using Newtonsoft.Json;
using QuestionnairesService.Exceptions.Common.Exceptions;
using QuestionnairesService.Exceptions.Resources;

namespace QuestionnairesService.Application.Businessmans.Querys.GetInfoByBin;
public record GetInfoByBinQuery : IRequest<GetInfoByBinResponse>
{
    public string Bin { get; init; } = null!;
    public sealed class GetInfoByBinQueryHandler : IRequestHandler<GetInfoByBinQuery, GetInfoByBinResponse>
    {
        private readonly string _jsonFilePath = "./InitData/BanksRequisites.json";

        public GetInfoByBinQueryHandler(){}

        public async Task<GetInfoByBinResponse> Handle(GetInfoByBinQuery query, CancellationToken cancellationToken)
        {
            ValidateRequestAndThrow(query);

            try
            {
                using StreamReader streamReader = new StreamReader(_jsonFilePath);

                var json = await streamReader.ReadToEndAsync();
                var jsonObject = JsonConvert.DeserializeObject<CompanyDto>(json);

                if (jsonObject is not null)
                {
                    var bankRequisite = jsonObject.BanksRequisites.FirstOrDefault(c => c.Bin == query.Bin);

                    EntityNotFoundException.ThrowIfNull(bankRequisite, BanksRequisitesErrorString.BankRequisiteNotFoundTemplate, query.Bin);
                    return bankRequisite;
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

        private void ValidateRequestAndThrow(GetInfoByBinQuery query)
        {
            if (string.IsNullOrEmpty(query.Bin))
            {
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Поле 'ИНН' должно быть заполнено.");
            }
        }

        private class CompanyDto
        {
            [JsonProperty("limitedLiabilityCompanies")]
            public List<GetInfoByBinResponse> BanksRequisites { get; set; } = null!;
        }
    }
}
