using Microsoft.EntityFrameworkCore;
using maneroSub.Contexts;
using maneroSub.Helpers.Repositories;
using maneroSub.Helpers.Services;
using maneroSub.Models.Interfaces.Products;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Registrar dataContext
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));
//N�r man anv�nder sig av Irepository s� anv�nder den product repository
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
    