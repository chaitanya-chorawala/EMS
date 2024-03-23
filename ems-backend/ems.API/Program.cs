using ems.API.MiddlewareConfiguration;
using ems.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Serilog;
using System.IO.Compression;
using System.Reflection;
using System.Text;
using ems.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Serilog.Events;
using Serilog.Debugging;
using System.Diagnostics;
using NpgsqlTypes;
using Serilog.Sinks.PostgreSQL;

try
{
    var builder = WebApplication.CreateBuilder(args);
    ConfigurationManager configuration = builder.Configuration;

    var connectionString = configuration.GetConnectionString("connStr");

    IDictionary<string, ColumnWriterBase> columnWriters = new Dictionary<string, ColumnWriterBase>
    {
        {"raiseAt", new TimestampColumnWriter() },
        {"message", new RenderedMessageColumnWriter(NpgsqlDbType.Text) },        
        {"Method", new SinglePropertyColumnWriter("Method", PropertyWriteMethod.ToString,NpgsqlDbType.Text, "l") },
        {"Host", new SinglePropertyColumnWriter("Host", PropertyWriteMethod.ToString,NpgsqlDbType.Text, "l") },
        {"Path", new SinglePropertyColumnWriter("Path", PropertyWriteMethod.ToString,NpgsqlDbType.Text, "l") },
        {"StatusCode", new SinglePropertyColumnWriter("StatusCode", PropertyWriteMethod.ToString,NpgsqlDbType.Text) },
        {"RequestAt", new SinglePropertyColumnWriter("RequestAt", PropertyWriteMethod.ToString,NpgsqlDbType.Text) },
        {"ResponseAt", new SinglePropertyColumnWriter("ResponseAt", PropertyWriteMethod.ToString,NpgsqlDbType.Text) },
        {"QueryString", new SinglePropertyColumnWriter("QueryString", PropertyWriteMethod.ToString,NpgsqlDbType.Text, "l") },
        {"RequestBody", new SinglePropertyColumnWriter("RequestBody", PropertyWriteMethod.ToString,NpgsqlDbType.Text, "l") },
        {"ResponseBody", new SinglePropertyColumnWriter("ResponseBody", PropertyWriteMethod.ToString,NpgsqlDbType.Text, "l") },
        {"exception", new ExceptionColumnWriter() }
    };


Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Information()
        .WriteTo.PostgreSQL(
       connectionString,
       tableName: "Logs",
       schemaName: "Logging",
       columnOptions: columnWriters,
       restrictedToMinimumLevel: LogEventLevel.Information,
       needAutoCreateTable: true,
       respectCase: true)
        .CreateLogger();

    SelfLog.Enable(msg =>
    {
        Debug.Print(msg);
        Debugger.Break();
    });

    Log.Information("Application started");
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

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseNpgsql(configuration.GetConnectionString("connStr"), sqlServerOptionsAction =>
        {
            sqlServerOptionsAction.CommandTimeout(180);
            sqlServerOptionsAction.EnableRetryOnFailure(2);
            sqlServerOptionsAction.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
        });
        options.EnableSensitiveDataLogging();
        options.EnableDetailedErrors();
        options.LogTo(Console.WriteLine);
    });
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

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
            Title = "EMS Event APIs",
            Description = "EMS event management APIs"
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
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "EMS Event APIs");
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
    Log.Fatal(ex, ex.Message);
    throw;
}