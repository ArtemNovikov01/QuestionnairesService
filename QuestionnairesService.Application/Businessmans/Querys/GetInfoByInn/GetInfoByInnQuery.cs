using MediatR;
using QuestionnairesService.Application.Services;
using QuestionnairesService.Exceptions.Common.Exceptions;
using Newtonsoft.Json;
using QuestionnairesService.Models.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuestionnairesService.Application.Businessmans.Querys.GetInfoByInn;
public record GetInfoByInnQuery : IRequest<GetInfoByInnResponse>
{
    public string Inn { get; init; } = null!;
    public sealed class GetInfoByInnQueryHandler : IRequestHandler<GetInfoByInnQuery, GetInfoByInnResponse>
    {
        private readonly IQuestionnairesServiceDbContext _questionnairesServiceDbContext;
        private readonly string _jsonFilePath = "C:/Users/novikovaa/source/QuestionnairesService/QuestionnairesService/QuestionnairesService.Application/Businessmans/Querys/GetInfoByInn/LimitedLiabilityCompanies.json";

        public GetInfoByInnQueryHandler(IQuestionnairesServiceDbContext questionnairesServiceDbContext)
        {
            _questionnairesServiceDbContext = questionnairesServiceDbContext;
        }

        public async Task<GetInfoByInnResponse> Handle(GetInfoByInnQuery query, CancellationToken cancellationToken)
        {
            ValidateRequestAndThrow(query);

            using StreamReader streamReader = new StreamReader(_jsonFilePath);
            
            var json = await streamReader.ReadToEndAsync();
            var jsonObject = JsonConvert.DeserializeObject<RootObject>(json);

            if (jsonObject is not null)
            {
                foreach (var company in jsonObject.GetInfoByInnResponses)
                {
                    if (company.Inn == query.Inn)
                    {
                        return company;
                    }
                }
            }

            throw new BadRequestException(ErrorCodes.Common.BadRequest, "Не одна организация не соответствует введённому ИНН.");
        }

        private void ValidateRequestAndThrow(GetInfoByInnQuery query)
        {
            if (string.IsNullOrEmpty(query.Inn))
            {
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Поле 'ИНН' должно быть заполнено.");
            }
        }

        public class RootObject
        {
            public List<GetInfoByInnResponse> GetInfoByInnResponses { get; set; }
        }
    }
}
