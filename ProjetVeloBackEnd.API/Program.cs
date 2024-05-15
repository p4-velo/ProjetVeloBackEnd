using Microsoft.EntityFrameworkCore;
using ProjetVeloBackEnd.DAL;
using ProjetVeloBackEnd.DAL.Contracts;
using ProjetVeloBackEnd.DAL.Contracts.IRepositories;
using ProjetVeloBackEnd.DAL.Repositories;
using ProjetVeloBackEnd.Services;
using ProjetVeloBackEnd.Services.Contracts;
using ProjetVeloBackEnd.Services.Contracts.Models;
using ProjetVeloBackEnd.Services.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICRUDService<>),typeof(CRUDService<>));
builder.Services.AddScoped<IFavoritePlaceService,FavoritePlaceService>();
builder.Services.AddScoped<IFavoritePlaceRepository,FavoritePlaceRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();