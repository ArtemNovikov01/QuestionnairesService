using Microsoft.EntityFrameworkCore;
using QuestionnairesService.Models.Entities;

namespace QuestionnairesService.Application.Services;
public interface IQuestionnairesServiceDbContext
{
    public DbSet<Organization> Organizations { get; }
    public DbSet<Bank> Banks { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
