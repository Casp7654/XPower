using XPowerApi.Models.UserModels;
using System.Text;
using XPowerApi.Interfaces;
using XPowerApi.Managers;
using XPowerApi.Providers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using XPowerApi.Supporters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Add swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", //Name the security scheme
        new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme.",
            Type = SecuritySchemeType.Http, //We set the scheme type to http since we're using bearer authentication
            Scheme = "Bearer", //The name of the HTTP Authorization scheme to be used in the Authorization header. In this case "bearer".
            In = ParameterLocation.Header
        });
    c.AddSecurityRequirement(
        new OpenApiSecurityRequirement()
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
                new string[] { }
            }
        });
});

// Add scoped services.
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IHomeManager, HomeManager>();
builder.Services.AddScoped<IHubManager, HubManager>();
builder.Services.AddScoped<ITokenManager<UserToken>, TokenManager>();
builder.Services.AddScoped<IUserProvider, UserProvider>();
builder.Services.AddScoped<IHomeProvider, HomeProvider>();
builder.Services.AddScoped<IHubProvider, HubProvider>();
builder.Services.AddScoped<ISurrealDbProvider, SurrealDbProvider>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

// Add authentication for bearer tokens.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add cors.
app.UseCors(policyBuilder =>
{
    policyBuilder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});

// Let application use controlls, authentication, authorization and redirects.
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();