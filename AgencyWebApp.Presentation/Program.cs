using AgencyWebApp.API.Extensions;
using AgencyWebApp.Application.Profiles;
using AgencyWebApp.Application.Services.Interfaces;
using AgencyWebApp.Infrastructure.Data;
using AgencyWebApp.Infrastructure.Services;
using Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptionsAction: sqlOptions =>
        {
            // Все настройки SQL Server должны быть ЗДЕСЬ
            sqlOptions.MigrationsAssembly("AgencyWebApp.Infrastructure");
            
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 15,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
        }
    ));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
builder.Services.AddMemoryCache(); 
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddAuth();
builder.Services.AddScoped<IEmailService, GmailService>();
var jwtSecret = builder.Configuration["Jwt:Secret"]
    ?? throw new Exception("Jwt:Secret is missing in appsettings.json");

var key = Encoding.UTF8.GetBytes(jwtSecret);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Agency Web API",
        Version = "v1"
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "������� JWT ����� ���: Bearer {token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        Console.WriteLine("--> Проверка базы данных...");
        // Эта команда создаст саму базу и таблицы
        context.Database.EnsureCreated(); 
        Console.WriteLine("--> УРА! База данных TravelDb готова к работе.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"--> ОШИБКА СОЗДАНИЯ БАЗЫ: {ex.Message}");
    }
}

app.MapControllers();
app.Run();