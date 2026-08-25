using Microsoft.EntityFrameworkCore;
using FinancialAnalytics.Api;
using FinancialAnalytics.Api.Services;

var builder = WebApplication.CreateBuilder(args);
var fakeErpConnection = builder.Configuration.GetConnectionString("FakeErp");
if (string.IsNullOrWhiteSpace(fakeErpConnection))
    throw new InvalidOperationException("FakeErp connection string is missing.");

var analyticsConnection = builder.Configuration.GetConnectionString("FinancialAnalytics");
if (string.IsNullOrWhiteSpace(analyticsConnection))
    throw new InvalidOperationException("FinancialAnalytics connection string is missing.");

builder.Services.AddDbContext<FakeErpDbContext>(options => options.UseSqlServer(fakeErpConnection));
builder.Services.AddDbContext<FinancialAnalyticsDbContext>(options => options.UseSqlServer(analyticsConnection));
builder.Services.AddCors(options => options.AddPolicy("frontend", policy =>
    policy.WithOrigins("http://localhost:3000", "http://localhost:3001", "http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod()));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IErpExtractor, ErpExtractor>();
builder.Services.AddScoped<IDataTransformer, DataTransformer>();
builder.Services.AddScoped<IDataValidator, DataValidator>();
builder.Services.AddScoped<IDataLoader, DataLoader>();
builder.Services.AddScoped<IAnalyticsReadService, AnalyticsReadService>();

builder.Services.AddScoped<PipelineService>();
builder.Services.AddScoped<IReportingService, ReportingService>();

var app = builder.Build();

await using (var scope = app.Services.CreateAsyncScope())
{
    await scope.ServiceProvider.GetRequiredService<FakeErpDbContext>().Database.MigrateAsync();
    await scope.ServiceProvider.GetRequiredService<FinancialAnalyticsDbContext>().Database.MigrateAsync();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("frontend");
app.MapControllers();

app.Run();

public partial class Program
{
}
