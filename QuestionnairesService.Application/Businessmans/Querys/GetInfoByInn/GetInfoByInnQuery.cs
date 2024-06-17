using MediatR;
using Newtonsoft.Json;
using QuestionnairesService.Application.Services;
using QuestionnairesService.Exceptions.Common.Exceptions;

namespace QuestionnairesService.Application.Businessmans.Querys.GetInfoByInn;
public record GetInfoByInnQuery : IRequest<GetInfoByInnResponse>
{
    public string Inn { get; init; } = null!;
    public sealed class GetInfoByInnQueryHandler : IRequestHandler<GetInfoByInnQuery, GetInfoByInnResponse>
    {
        private readonly IQuestionnairesServiceDbContext _questionnairesServiceDbContext;

        public GetInfoByInnQueryHandler(IQuestionnairesServiceDbContext questionnairesServiceDbContext)
        {
            _questionnairesServiceDbContext = questionnairesServiceDbContext;
        }

        public async Task<GetInfoByInnResponse> Handle(GetInfoByInnQuery query, CancellationToken cancellationToken)
        {
            ValidateRequestAndThrow(query);
            //ToDo Разобраться с относительным путём к файлу
            string _jsonFilePath = "Businessmans/Querys/GetInfoByInn/LimitedLiabilityCompanies.json";
            string absolutePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _jsonFilePath);
            try
            {
                using StreamReader streamReader = new StreamReader(absolutePath);

                var json = await streamReader.ReadToEndAsync();
                var jsonObject = JsonConvert.DeserializeObject<CompanyDto>(json);

                if (jsonObject is not null)
                {
                    return jsonObject.CompanyInfo.FirstOrDefault(c => c.Inn == query.Inn)
                        ?? throw new BadRequestException(ErrorCodes.Common.BadRequest, "Ни одна организация не соответствует введённому ИНН.");
                }
            }
            catch (DirectoryNotFoundException)
            {
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Указан неверный путь");
            }
            catch (Exception)
            {
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Файл повреждён");
            }

            throw new BadRequestException(ErrorCodes.Common.BadRequest, "Не заданы начальные данные");
        }

        private void ValidateRequestAndThrow(GetInfoByInnQuery query)
        {
            if (string.IsNullOrEmpty(query.Inn))
            {
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Поле 'ИНН' должно быть заполнено.");
            }
        }

        private class CompanyDto
        {
            [JsonProperty("limitedLiabilityCompanies")]
            public List<GetInfoByInnResponse> CompanyInfo { get; set; } = null!;
        }
    }
}
