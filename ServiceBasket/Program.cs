using Microsoft.EntityFrameworkCore;
using ServiceBasket.Contractes;
using ServiceBasket.Data;
using ServiceBasket.Infrastructure;
using ServiceBasket.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//Data base
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ContextDB>(options => options.UseSqlite(connectionString));


//Dependencies
builder.Services.AddScoped<IProductesRep, ProductRepository>();
builder.Services.AddScoped<IOrdersRep, OrdersRepository>();
builder.Services.AddScoped<IOrderUserRep, OrderUserRepository>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
