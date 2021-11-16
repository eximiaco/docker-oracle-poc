using System;
using docker_oracle_poc.Data;
using docker_oracle_poc.Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Database");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(optionsBuilder => optionsBuilder.UseOracle(connectionString));

// var app = builder.Build();
//
// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

using var dbContext = builder.Services.BuildServiceProvider().GetService<DataContext>();

var random = new Random((int)DateTime.Now.Ticks);

dbContext.Certificates.Add(new Certificate
{
    Id = Guid.NewGuid(),
    Number = random.Next()
});  
//
//
// app.UseAuthorization();
//
// app.MapControllers();
//
// app.Run();