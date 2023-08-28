using Microsoft.EntityFrameworkCore;
using Onion.Api.Extensions;
using Onion.Library.SPI.Persistence;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDIConfigurations();

// Regestring Postgress Sql
builder.Services.AddDbContext<RepositoryDbContext>(options=>
                            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),
                            x=>x.MigrationsHistoryTable("_EfMigrations", Configuration.GetSection("Schema").GetSection("ProductDataSchema").Value)));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Performing initial migration when application is started
using(var serviceScope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope())
{
    var context = serviceScope?.ServiceProvider.GetRequiredService<RepositoryDbContext>();
    context?.Database.Migrate();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
