using Microsoft.EntityFrameworkCore;
using Taskey.Server.Application;
using Taskey.Server.Data;
using Taskey.Server.Data.Repositories;
using Taskey.Server.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Register the in-memory database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("TaskeyDb"));

builder.Services.AddScoped<ITaskItemRepository, TaskItemRepository>();

builder.Services.AddScoped<ITaskItemService, TaskItemService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
