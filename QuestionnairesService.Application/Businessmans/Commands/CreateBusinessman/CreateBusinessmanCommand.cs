using MediatR;
using QuestionnairesService.Application.Services;

namespace QuestionnairesService.Application.Businessmans.Commands.CreateBusinessman;
public record CreateBusinessmanCommand: IRequest<CreateBusinessmanResponse>
{
    public string Name { get; init; } = null!;
    public sealed class CreateArticleTagCommandHandler : IRequestHandler<CreateBusinessmanCommand, CreateBusinessmanResponse>
    {
        private readonly IQuestionnairesServiceDbContext _questionnairesServiceDbContext;

        public CreateArticleTagCommandHandler(IQuestionnairesServiceDbContext questionnairesServiceDbContext)
        {
            _questionnairesServiceDbContext = questionnairesServiceDbContext;
        }

        public async Task<CreateBusinessmanResponse> Handle(CreateBusinessmanCommand request, CancellationToken cancellationToken)
        {
            return null;
        }

        private void ValidateRequestAndThrow(CreateBusinessmanCommand command)
        {
        }
    }
}
