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
//builder.Services.AddDbContext<ContextDB>(options => options.UseSqlServer(connectionString));

//Dependencies
builder.Services.AddScoped<IProductesRep, ProductRepository>();
builder.Services.AddScoped<IOrdersRep, OrdersRepository>();
builder.Services.AddScoped<IOrderUserRep, OrderUserRepository>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
