using DrumBeatsUI.Mappings;
using DrumBeatsUI.Models;
using DrumBeatsUI.Services;
using NLog;
using NLog.Web;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("Init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddMvc();
    builder.Services.AddHttpClient<IExerciseService, ExerciseService>(c =>
    {
        c.BaseAddress = new Uri("https://localhost:7248");
        c.DefaultRequestHeaders.Add("Accept", "application/.json");
    });
    builder.Services.AddHttpClient<ISongService, SongService>(c =>
    {
        c.BaseAddress = new Uri("https://localhost:7248");
        c.DefaultRequestHeaders.Add("Accept", "application/.json");
    });

    builder.Services.AddAutoMapper(cfg => cfg.AddProfile<ExerciseProfile>());
    builder.Services.AddAutoMapper(cfg => cfg.AddProfile<SongProfile>());

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Song}/{action=Songs}");

    app.UseAuthorization();

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
}
finally
{
    LogManager.Shutdown();
}
