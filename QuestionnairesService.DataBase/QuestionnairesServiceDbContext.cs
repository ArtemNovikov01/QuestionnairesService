using Microsoft.EntityFrameworkCore;
using QuestionnairesService.Application.Services;
using QuestionnairesService.Models.Entities;

namespace QuestionnairesService.DataBase;
public class QuestionnairesServiceDbContext : DbContext, IQuestionnairesServiceDbContext
{
    public QuestionnairesServiceDbContext(DbContextOptions<QuestionnairesServiceDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<LimitedLiabilityCompany> LimitedLiabilityCompanies => Set<LimitedLiabilityCompany>();

}
