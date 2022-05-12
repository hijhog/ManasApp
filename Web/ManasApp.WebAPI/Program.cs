using ManasApp.Data;
using ManasApp.Data.Contract.Repositories;
using ManasApp.Data.Repositories;
using ManasApp.Data.Seeder;
using ManasApp.Services;
using ManasApp.Services.Contract.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(optoins =>
{
    optoins.UseSqlServer(connectionString);
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ILocalityRepository, LocalityRepository>();
builder.Services.AddScoped<ILocalityService, LocalityService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    LocalitySeeder.Initialize(builder.Services);

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
