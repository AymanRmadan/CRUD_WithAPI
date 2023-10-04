using CRUD_WithAPI.Data;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//===============================================================
//builder.Services.AddDbContext<APIDbContext>(option => option.UseInMemoryDatabase("ContactDB"));
builder.Services.AddDbContext<APIDbContext>(option => 
option.UseSqlServer(builder.Configuration.GetConnectionString("APIContactConnectionStrings")));

//===============================================================
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
