using Microsoft.OpenApi.Models;
using WeatherForecastService.Services;
using WeatherForecastService.Validators;
using TheWeatherForecastService = WeatherForecastService.Services.WeatherGovService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IForecastService, ForecastService>();
builder.Services.AddSingleton<ForecastRequestValidator>();
builder.Services.AddHttpClient<IGeoService, GeoService>(c =>
{
    c.BaseAddress = new Uri("http://localhost:5201");
});

builder.Services.AddHttpClient<IWeatherGovService, TheWeatherForecastService>(c =>
{
    c.BaseAddress = new Uri("https://api.weather.gov");
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(UnitCodeConverter.Singleton);
    options.JsonSerializerOptions.Converters.Add(TemperatureUnitConverter.Singleton);

});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Geocoding API", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllOrigins",
    builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
