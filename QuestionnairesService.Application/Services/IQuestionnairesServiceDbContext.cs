using Microsoft.EntityFrameworkCore;
using QuestionnairesService.Models.Entities;

namespace QuestionnairesService.Application.Services;
public interface IQuestionnairesServiceDbContext
{
    public DbSet<IndividualEntrepreneur> IndividualEntrepreneurs { get; }
    public DbSet<LimitedLiabilityCompany> LimitedLiabilityCompanies { get; }
    public DbSet<BankRequisites> BankRequisites { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
