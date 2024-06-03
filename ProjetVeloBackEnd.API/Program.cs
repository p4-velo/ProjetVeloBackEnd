using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.OpenApi.Models;
using ProjetVeloBackEnd.DAL;
using ProjetVeloBackEnd.DAL.Contracts;
using ProjetVeloBackEnd.Entities;
using ProjetVeloBackEnd.Services;
using ProjetVeloBackEnd.Services.Contracts;
using ProjetVeloBackEnd.Services.Contracts.Models;
using ProjetVeloBackEnd.Services.Models;
using static Microsoft.AspNetCore.Http.StatusCodes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// setting up the swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement
    (new OpenApiSecurityRequirement
    {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
                new string[]{}
            }
    });
});

// add authentication
builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddAuthorization();

// configure dbcontext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services
    .AddIdentityCore<User>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddApiEndpoints();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICRUDService<>), typeof(CRUDService<>));
builder.Services.AddScoped<IFavoritePlaceService, FavoritePlaceService>();
builder.Services.AddScoped<ILocationService, LocationService>();

builder.Services.AddHttpsRedirection(options =>
{
    options.RedirectStatusCode = Status307TemporaryRedirect;
    options.HttpsPort = 5001;
});



var app = builder.Build();

app.MapIdentityApi<User>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseAuthorization();

app.MapControllers();

app.Run();