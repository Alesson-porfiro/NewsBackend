using GeoIntelligence.Api.API.Routes;
using GeoIntelligence.Api.Application.Services;
using GeoIntelligence.Api.Infrastructure.Integrations;

var builder = WebApplication.CreateBuilder(args);

// =======================
// SERVICES
// =======================
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendPolicy", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// News
builder.Services.AddHttpClient<WorldNewsTubeClient>();
builder.Services.AddScoped<NewsTubeService>();

// Crypto
builder.Services.AddHttpClient<CryptoClient>();
builder.Services.AddScoped<CryptoService>();

var app = builder.Build();

// =======================
// MIDDLEWARE
// =======================
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "GeoIntelligence API v1");
    c.RoutePrefix = "swagger";
});

app.UseCors("FrontendPolicy");

// ⚠️ HTTPS apenas local
if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

// =======================
// ROUTES
// =======================
app.MapGroup("/api/news/br").MapNewsTubeRoutes();
app.MapGroup("/api/crypto/br").MapNewsCryptoRoutes();

app.Run();
