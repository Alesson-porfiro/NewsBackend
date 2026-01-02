using GeoIntelligence.Api.API.Routes;
using GeoIntelligence.Api.Application.Services;
using GeoIntelligence.Api.Infrastructure.Integrations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendPolicy", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 🔓 ATIVAR CORS (ANTES DAS ROTAS)
app.UseCors("FrontendPolicy");

app.UseHttpsRedirection();

// =======================
// ROUTES
// =======================
app.MapGroup("/api/news/br").MapNewsTubeRoutes();
app.MapGroup("/api/crypto/br").MapNewsCryptoRoutes();

app.Run();
