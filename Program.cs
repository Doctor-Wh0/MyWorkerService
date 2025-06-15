using Microsoft.EntityFrameworkCore;
using MyWorkerService;
using MyWorkerService.Clients;
using MyWorkerService.Repositories;
using Microsoft.Extensions.Http;


var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddDbContext<PostgresDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

builder.Services.AddHttpClient<IApiClient, MoexClient>(client =>
{
    client.BaseAddress = new Uri("https://api.moex.com/"); // Настройте базовый URL
}); 
builder.Services.AddScoped<MyWorkerService.Services.DataLoaderService>();
builder.Services.AddScoped<IDataRepository, PostgresDataRepository>();



var host = builder.Build();
host.Run();