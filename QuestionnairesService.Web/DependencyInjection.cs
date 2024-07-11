using QuestionnairesService.Backend.Setting;
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

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost3000",
                    builder => builder
                        .WithOrigins("http://localhost:3000")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            // Swagger
            builder.Services
                .AddSwaggerGen();

            return builder;
        }

        public static WebApplication ConfigureWebApplication(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(opt => { opt.SwaggerEndpoint("v1/swagger.json", "Registartion Organization"); });

            app.UseRouting();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Cors
            if (!app.Environment.IsProduction())
            {
                app.UseCors(cfg => cfg
                    .WithOrigins("http://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials());
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.MapControllers();

            //app.UseReact(config => { });
            //app.UseDefaultFiles();
            //app.UseStaticFiles();

            return app;
        }
    }
}
