using rayna.API.MiddlewareConfiguration;
using rayna.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Serilog;
using System.IO.Compression;
using System.Reflection;
using System.Text;

try
{
    var builder = WebApplication.CreateBuilder(args);
    ConfigurationManager configuration = builder.Configuration;

    //g-zip for faster response
    builder.Services.Configure<GzipCompressionProviderOptions>(options =>
    {
        options.Level = CompressionLevel.SmallestSize;
    });

    //Adding CORS
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("ApiCorsPolicy", builder =>
        {
            string allowedOriginAddress = configuration.GetValue<string>("AllowedCorsUrls")!;
            var addresses = allowedOriginAddress.Split(';');

            builder
                .WithOrigins(addresses)
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
    });
    // Add services to the container.
    builder.Services.AddPersistenceServices(configuration);

builder.Services.AddHttpContextAccessor();
    builder.Services.AddControllers().AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        options.SerializerSettings.ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy(true, false)
        };
        options.SerializerSettings.DateFormatString = "dd-MMM-yyyy";
    });
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        options.IncludeXmlComments(xmlPath);

        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Rayna Event APIs",
            Description = "Rayna event management APIs"
        });

        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Description = "Bearer authentication with JWT token",
            Type = SecuritySchemeType.Http
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            }, new List<string>()
        }
        });

    });

    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]!))
        };
    });

    var app = builder.Build();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Rayna Event APIs");
    });
  

    app.UseHttpsRedirection();

    app.UseCors("ApiCorsPolicy");

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseMiddleware<RequestResponseLoggingMiddleware>();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex.Message);
    throw;
}