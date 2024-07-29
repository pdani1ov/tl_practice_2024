using Domain.Repositories;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TheatreDbContext>( options =>
{
    options.UseSqlServer(
        "Server=LAPTOP-J0D17NIN\\SQLEXPRESS;Database=Theatre;Trusted_Connection=True;TrustServerCertificate=True;" );
} );
builder.Services.AddScoped( typeof( IRepository<> ), typeof( Repository<> ) );
builder.Services.AddScoped<IPlayRepository, PlayRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
