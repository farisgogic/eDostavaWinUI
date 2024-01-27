using AutoMapper;
using eDostava.Filter;
using eDostava.Services;
using eDostava.Services.Database;
using eDostava.Services.Dostavljac;
using eDostava.Services.JelaOcjene;
using eDostava.Services.Jelo;
using eDostava.Services.Kategorija;
using eDostava.Services.Kupci;
using eDostava.Services.Narudzba;
using eDostava.Services.Omiljeni;
using eDostava.Services.Review;
using eDostava.Services.Services.Korisnik;
using eDostava.Services.Services.Restoran;
using eDostava.Services.Uloga;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(x =>
{
    x.Filters.Add<ErrorFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("basicAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "basic"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme, Id = "basicAuth"
                },
            },
            new string[]{}
        }
    });
});

builder.Services.AddTransient<IKorisnikService, KorisnikService>();
builder.Services.AddTransient<IRestoranService, RestoranService>();
builder.Services.AddTransient<IUlogaService, UlogaService>();
builder.Services.AddTransient<IKategorijaService, KategorijaService>();
builder.Services.AddTransient<IJeloService, JeloService>();
builder.Services.AddTransient<IKupciService, KupciService>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddTransient<IOmiljeniService, OmiljeniService>();
builder.Services.AddTransient<INarudzbaService, NarudzbeService>();
builder.Services.AddTransient<IDostavljacService, DostavljacService>();
builder.Services.AddTransient<IRecenzijaService, RecenzijaService>();
builder.Services.AddTransient<IJelaOcjeneService, JelaOcjeneService>();


builder.Services.AddAutoMapper(typeof(IKorisnikService));

builder.Services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthentitacionHandler>("BasicAuthentication", null);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DostavaContext>(options =>
    options.UseSqlServer(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DostavaContext>();
    dbContext.Database.Migrate();
}


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
