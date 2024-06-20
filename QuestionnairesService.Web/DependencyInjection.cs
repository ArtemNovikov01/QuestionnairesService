﻿using QuestionnairesService.Backend.Setting;
using System.Text.Json;
using System.Text.Json.Serialization;
using QuestionnairesService.DataBase;
using QuestionnairesService.Application;
using React.AspNet;
using JavaScriptEngineSwitcher.ChakraCore;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;

namespace QuestionnairesService.Backend
{
    public static class DependencyInjection
    {
        public static WebApplicationBuilder BuildWebApplication(this WebApplicationBuilder builder)
        {
            var webAppSettings = builder.Configuration.Get<WebAppSettings>()
                             ?? throw new NullReferenceException("Не заданы настройки приложения");

            // Services
            builder.Services
                .AddDatabase(webAppSettings.Database)
                .AddApplication()
                .AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                //.AddReact()
                //.AddJsEngineSwitcher(o => 
                //    o.DefaultEngineName = ChakraCoreJsEngine.EngineName)
                //        .AddChakraCore(); 

            builder.Services
                .AddMvc()
                .AddJsonOptions(o =>
                {
                    o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                });

            // Swagger
            builder.Services
                .AddSwaggerGen();

            return builder;
        }

        public static WebApplication ConfigureWebApplication(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(opt => { opt.SwaggerEndpoint("v1/swagger.json", "AllSharing Backend"); });

            app.UseRouting();

            app.MapControllers();

            //app.UseReact(config => { });
            //app.UseDefaultFiles();
            //app.UseStaticFiles();

            return app;
        }
    }
}
