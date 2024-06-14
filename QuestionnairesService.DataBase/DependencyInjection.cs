using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuestionnairesService.Application.Services;
using QuestionnairesService.DataBase.Setting;

namespace QuestionnairesService.DataBase;
public static class DependencyInjection
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, DatabaseSettings? databaseSettings)
    {
        if (databaseSettings?.ConnectionString is null)
        {
            throw new ArgumentNullException(nameof(databaseSettings), "Не заданы настройки БД");
        }

        services.AddDbContext<QuestionnairesServiceDbContext>(opt => opt.UseNpgsql(databaseSettings.ConnectionString));
        services.AddScoped<IQuestionnairesServiceDbContext>(isp => isp.GetRequiredService<QuestionnairesServiceDbContext>());

        return services;
    }
}
