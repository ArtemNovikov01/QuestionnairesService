using Microsoft.EntityFrameworkCore;
using QuestionnairesService.Application.Services;
using QuestionnairesService.Models.Entities;
using System.Reflection;

namespace QuestionnairesService.DataBase;
public class QuestionnairesServiceDbContext : DbContext, IQuestionnairesServiceDbContext
{
    public QuestionnairesServiceDbContext(DbContextOptions<QuestionnairesServiceDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Organization> Organizations => Set<Organization>();
    public DbSet<Bank> Banks => Set<Bank>();
}
