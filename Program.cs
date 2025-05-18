using Microsoft.EntityFrameworkCore;
using MyWorkerService;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    );
//builder.Services.AddLogging

var host = builder.Build();
host.Run();
