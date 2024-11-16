using FirstWebApi.Bll.Base;
using FirstWebApi.Bll.Components.DirectorComponent.Services;
using FirstWebApi.Bll.Components.FilmComponent.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddScoped<FilmService>();
builder.Services.AddScoped<DirectorService>();
builder.Services.AddControllers();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1",
        Description = "Документування API з використанням Swagger у .NET Core 8.0",
        Contact = new OpenApiContact
        {
            Name = "Andrii Dorozhko",
            Email = "dorozhko.andrii1119@vu.cdu.edu.ua"
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.MapControllers();
app.Run();
