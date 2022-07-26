using Microsoft.EntityFrameworkCore;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Implementations;
using ShopeeFoodDemoBE.DAL.EF.Data;
using ShopeeFoodDemoBE.DAL.Repos.Constracts;
using ShopeeFoodDemoBE.DAL.Repos.Implementations;
using System.Web.Http.Cors;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*");
                          policy.WithMethods("*");
                          policy.WithHeaders("*");
                      });
});

//Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

builder.Services.AddTransient<ICityService, CityService>();
builder.Services.AddTransient<ICityRepository, CityRepository>();

builder.Services.AddTransient<IRestaurantTypeService, RestaurantTypeService>();
builder.Services.AddTransient<IRestaurantTypeRepository, RestaurantTypeRepository>();

builder.Services.AddTransient<IRestaurantService, RestaurantService>();
builder.Services.AddTransient<IRestaurantRepository, RestaurantRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseCors(MyAllowSpecificOrigins); //TODO: rename

app.Run();
