using AutoMapper;
using Business;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// HttpClient Configuration
builder.Services.AddHttpClient(); // For external API calls

// Dependency Injection for Repositories and Services
builder.Services.AddScoped<ISqlRepository, SqlRepository>();
builder.Services.AddScoped<IMongoRepository, MongoRepository>();
builder.Services.AddScoped<ITeacherService, TeacherService>();

// SQL Server Configuration
builder.Services.AddDbContext<SqlDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

// MongoDB Configuration
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("MongoDbConnection");
    return new MongoClient(connectionString);
});

builder.Services.AddSingleton<MongoDbContext>(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    var databaseName = "schoolDb"; // Replace with your actual database name or read from configuration
    return new MongoDbContext(client, databaseName);
});

// AutoMapper Configuration
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Swagger/OpenAPI Configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();