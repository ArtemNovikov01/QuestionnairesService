using QuestionnairesService.DataBase.Setting;

namespace QuestionnairesService.Backend.Setting
{
    public sealed record WebAppSettings
    {
        /// <summary>
        /// Настройки БД
        /// </summary>
        public DatabaseSettings? Database { get; init; }
    }
}
