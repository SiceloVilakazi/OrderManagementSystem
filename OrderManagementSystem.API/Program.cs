global using OrderManagementSystem.Domain;
global using OrderManagementSystem.Infrastructure;
global using OrderManagementSystem.Queries;
global using OrderManagementSystem.Commands;
global using MediatR;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NLog;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

ConfigurationManager config = builder.Configuration;
// Add services to the container.


var queryAssembly = typeof(GetAllProductsQuery).GetTypeInfo().Assembly;
builder.Services.AddMediatR(queryAssembly);

var commandAssembly = typeof(AddProductCommand).GetTypeInfo().Assembly;
builder.Services.AddMediatR(commandAssembly);

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Services
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IOrderStateService, OrderStateService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IStockService, StockService>();
builder.Services.AddTransient<ILoggerManager, LoggerManager>();

//Repositories
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IOrderStateRepository, OrderStateRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IStockRepository, StockRepository>();


builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


builder.Services.AddDbContext<OrderManagementDBContext>
  (options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Order Management System API",
        Description = "An ASP.NET Core Web API for managing orders, stocks and products",

    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
