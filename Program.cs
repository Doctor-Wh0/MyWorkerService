using MyWorkerService;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
//builder.Services.AddLogging

var host = builder.Build();
host.Run();
