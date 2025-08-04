using Microsoft.EntityFrameworkCore;
using TickerQ.Dashboard.DependencyInjection;
using TickerQ.DependencyInjection;
using TickerQ.EntityFrameworkCore.DependencyInjection;
using TickerScheduling;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer("Data Source=localhost;Initial Catalog=tickerQScheduling;Integrated Security=True;TrustServerCertificate=True;");
});

builder.Services.AddTickerQ(options =>
{
    options.AddOperationalStore<MyDbContext>(efOpt =>
    {
        efOpt.UseModelCustomizerForMigrations();
        efOpt.CancelMissedTickersOnApplicationRestart();
    });

    options.SetMaxConcurrency(4);
    options.AddDashboard(basePath: "/dashboard");
    options.AddDashboardBasicAuth();
});

var app = builder.Build();

app.UseTickerQ();

app.MapGet("/", () => "Hello World!");

app.Run();
