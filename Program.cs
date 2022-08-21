using ChellengeE;
using ChellengeE.Repository;
using ChellengeE.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

var MyCors = "MyCors";

SD.UrlApiBase = configuration["BaseUrl"];
SD.ApiKey = configuration["ApiKey"];

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyCors, builder =>
    {
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
        builder.AllowAnyOrigin();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<INewApiRepository, NewApiRepository>();
builder.Services.AddScoped<INewApiRepository, NewApiRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(MyCors);

app.MapControllers();

app.Run();
