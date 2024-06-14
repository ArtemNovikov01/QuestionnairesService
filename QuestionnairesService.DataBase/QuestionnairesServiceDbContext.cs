using Microsoft.EntityFrameworkCore;
using QuestionnairesService.Application.Services;
using QuestionnairesService.Models.Entities;

namespace QuestionnairesService.DataBase;
public class QuestionnairesServiceDbContext : DbContext, IQuestionnairesServiceDbContext
{
    public DbSet<IndividualEntrepreneur> IndividualEntrepreneurs { get; set; }
    public DbSet<LimitedLiabilityCompany> LimitedLiabilityCompanies { get; set; }
    public DbSet<BankRequisites> BankRequisites { get; set; }
    public QuestionnairesServiceDbContext(DbContextOptions options) : base(options) { }

}
