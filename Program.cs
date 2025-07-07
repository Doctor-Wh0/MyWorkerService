using Microsoft.EntityFrameworkCore;
using MyWorkerService;
using MyWorkerService.Providers;
using MyWorkerService.Repositories;
using Microsoft.Extensions.Http;


var builder = Host.CreateApplicationBuilder(args);

builder.Configuration.AddJsonFile("LoadOptions.json");
builder.Services.Configure<LoadOptions>(builder.Configuration);

builder.Services.AddHostedService<Worker>();
builder.Services.AddDbContext<PostgresDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

builder.Services.AddHttpClient<IDataProvider, MoexProvider>(client =>
{
    client.BaseAddress = new Uri("https://api.moex.com/"); // Настройте базовый URL
});


builder.Services.AddScoped<MyWorkerService.Services.DataLoader>();
builder.Services.AddTransient<IInstrumentRepository<Stock>, InstrumentRepository<Stock>>();
//builder.Services.AddTransient<IInstrumentRepository<Metal>, InstrumentRepository<Metal>>();


var host = builder.Build();
host.Run();