using BookShop.Models.Data;
using BookShop.Repositories;
using BookShop.Repositories.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<BookShopDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection
builder.Services.AddDbContext<BookShopDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

builder.Services.AddTransient(typeof(ICRUDRepository<>), typeof(CRUDRepository<>));
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ICartRepository, CartRepository>();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
