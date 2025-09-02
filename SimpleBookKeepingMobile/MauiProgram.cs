using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleBookKeepingMobile.AutoMapperProfiles;
using SimpleBookKeepingMobile.Database.DbContexts;
using SimpleBookKeepingMobile.Database.Interfaces;
using System.Diagnostics;
using SimpleBookKeepingMobile.CommandAndQueries;
using SimpleBookKeepingMobile.Extensions;
using SimpleBookKeepingMobile.InternalServices;
using SimpleBookKeepingMobile.InternalServices.Interfaces;

namespace SimpleBookKeepingMobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            var path = Path.Combine(FileSystem.AppDataDirectory, "SimpleBookKeepingMobile.db3");
            builder.Services.AddDbContext<MainContext>(opt =>
                opt.UseSqlite($"Data Source={path}"));

            builder.Services.AddScoped<IMainContext, MainContext>();
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(MauiProgram).Assembly));
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            builder.Services.AddAutoMapper(expression =>
            {
                expression.AddProfile<DbToViewModelProfile>();
                expression.AddProfile<CommandToDbModelProfile>();
            });

            builder.Services.AddSingleton<INotificationService, NotificationService>();
            builder.Services.AddRepositories();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            // Handle .NET MAUI exceptions
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                var exception = args.ExceptionObject as Exception;
                HandleGlobalException(exception);
            };

            // Handle task exceptions
            TaskScheduler.UnobservedTaskException += (sender, args) =>
            {
                HandleGlobalException(args.Exception);
                args.SetObserved();
            };

            // 1. Собираем приложение
            var app = builder.Build();

            // 2. Применяем миграции
            ApplyMigrations(app.Services);

            // 3. Возвращаем собранное приложение
            return app;
        }

        private static void HandleGlobalException(Exception ex)
        {
            // Log the exception
            Debug.WriteLine($"Global Exception: {ex}");

            // You can also show an alert to the user
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    ex.Message,
                    "OK");
            });
        }

        private static void ApplyMigrations(IServiceProvider services)
        {
            // Создаем "область" для получения сервисов.
            // Это лучшая практика, чтобы гарантировать, что DbContext будет правильно уничтожен.
            using var scope = services.CreateScope();

            try
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<MainContext>();

                // Вызываем метод, который применяет все ожидающие миграции.
                // Если БД не существует, она будет создана.
                dbContext.Database.Migrate();

                // Опционально: здесь же можно добавить начальные данные (сидинг)
                // SeedData(dbContext);
            }
            catch (Exception ex)
            {
                // Здесь можно залогировать ошибку, если миграция не удалась
                Debug.WriteLine($"An error occurred while migrating the database: {ex.Message}");
                // В реальном приложении используйте систему логирования
            }
        }
    }
}
