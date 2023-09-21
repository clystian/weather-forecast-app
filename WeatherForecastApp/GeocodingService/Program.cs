using GeocodingService.Services;
using GeocodingService.Validators;
using Microsoft.OpenApi.Models;
using TheGeocodingService = GeocodingService.Services.GeocodingService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<IGeocodingService, TheGeocodingService>(c =>
{
    c.BaseAddress = new Uri("https://geocoding.geo.census.gov/geocoder/");
});
builder.Services.AddTransient<GeocodeRequestValidator>();
builder.Services.AddTransient<BulkGeocodeRequestValidator>();

builder.Services.AddControllers();
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
