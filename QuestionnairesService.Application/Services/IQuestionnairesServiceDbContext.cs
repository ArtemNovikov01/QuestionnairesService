using Microsoft.EntityFrameworkCore;
using QuestionnairesService.Models.Entities;

namespace QuestionnairesService.Application.Services;
public interface IQuestionnairesServiceDbContext
{
    public DbSet<LimitedLiabilityCompany> LimitedLiabilityCompanies { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
