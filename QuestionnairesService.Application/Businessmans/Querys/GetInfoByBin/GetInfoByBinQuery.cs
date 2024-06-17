using MediatR;
using QuestionnairesService.Application.Services;

namespace QuestionnairesService.Application.Businessmans.Querys.GetInfoByBin;
public record GetInfoByBinQuery : IRequest<GetInfoByBinResponse>
{
    public string Inn { get; init; } = null!;
    public sealed class GetInfoByBinQueryHandler : IRequestHandler<GetInfoByBinQuery, GetInfoByBinResponse>
    {
        private readonly IQuestionnairesServiceDbContext _questionnairesServiceDbContext;

        public GetInfoByBinQueryHandler(IQuestionnairesServiceDbContext questionnairesServiceDbContext)
        {
            _questionnairesServiceDbContext = questionnairesServiceDbContext;
        }

        public async Task<GetInfoByBinResponse> Handle(GetInfoByBinQuery query, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
