using Sample.Web.Infrastructure.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services
        .AddCustomApiVersioning()
        .AddCustomCompressionResponse()
        .AddCustomCors(builder.Configuration)
        .AddCustomOpenApi()
        .AddCustomHealthChecks()
        .AddCustomAntiforgeryToken()
        ;  

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseCustomOpenApi();
}

app.UseStaticFiles();

app.UseCustomCompressionResponse();
app.UseCustomCors();
app.UseCustomAntiforgeryToken();
app.UseAcceptJsonHeader();

app
    .RegisterHealthChecks()
    .RegisterRoutes();
app.MapFallbackToFile("/index.html");

app.Run();

public partial class Program { }
