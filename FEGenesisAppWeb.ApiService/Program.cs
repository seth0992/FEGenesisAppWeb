using FEGenesisAppWeb.ApiService.Authentication;
using FEGenesisAppWeb.Core.Repositories.Auth;
using FEGenesisAppWeb.Core.Repositories;
using FEGenesisAppWeb.Core.Services.Audit;
using FEGenesisAppWeb.Core.Services.Auth;
using FEGenesisAppWeb.Core.Services;
using FEGenesisAppWeb.Database.Data;
using FEGenesisAppWeb.Models.Entities.Tenant;
using FEGenesisAppWeb.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mi API", Version = "v1" });

    // Configurar autenticación JWT en Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Ignorar referencias circulares
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

        // Mantener las mayúsculas/minúsculas de las propiedades
        options.JsonSerializerOptions.PropertyNamingPolicy = null;

        // Ignorar valores nulos
        options.JsonSerializerOptions.DefaultIgnoreCondition =
            JsonIgnoreCondition.WhenWritingNull;
    });


builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpContextAccessor();

#region servicios para autenticación
// Authentication services
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<ITenantRepository, TenantRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
builder.Services.AddScoped<IAuthAuditLogger, AuthAuditLogger>();

// Configuración de seguridad
builder.Services.Configure<SecurityOptions>(
    builder.Configuration.GetSection("Security"));

// Registrar servicios relacionados con tenant y autenticación
builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddSingleton<IEncryptionService, EncryptionService>();
builder.Services.AddScoped<ISecretService, SecretService>();
// Actualizar el registro del servicio de tokens
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ISecretRepository, SecretRepository>();

// Registrar el manejador de eventos personalizado
builder.Services.AddScoped<TenantJwtBearerEvents>();
builder.Services.AddScoped<IAuthenticationHandler, MultiTenantAuthenticationHandler>();
// JWT Configuration
// Agregar autenticación JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddScheme<JwtBearerOptions, MultiTenantAuthenticationHandler>(
    JwtBearerDefaults.AuthenticationScheme,
    options => {
        var jwtConfig = builder.Configuration.GetSection("JWT");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtConfig["ValidIssuer"],
            ValidAudience = jwtConfig["ValidAudience"],
        };
    });
#endregion

//User services

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapControllers(); // Agregado

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

// Add authentication middleware to pipeline
app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapDefaultEndpoints();

app.Run();

