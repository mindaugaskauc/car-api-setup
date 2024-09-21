/**
* Author: Mindaugas Kaucikas
* Date: 2024
* Program description: Program.cs 
* 
* Method:                 builder.Services.AddSqlite<PizzaContext>("Data Source=ContosoPizza.db");
*
* Description:            Registers PizzaContext with the ASP.NET Core dependency injection system
*                         Specifies that PizzaContext will use the SQLite database provider.
*                         Defines a SQLite connection string that points to a local file, ContosoPizza.db.
* 
* CreateDbIfNotExists():  app.CreateDbIfNotExists();
* method  
*
* Description:            This code calls the extension method that you defined in the Extensions class
*                         each time the app runs                  
*          
*/

using CarApi.Services;

// Additional using declarations
using CarApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add the PizzaContext for dependancy injection
builder.Services.AddSqlite<CarContext>("Data Source=Car.db");

// Add the PromotionsContext

builder.Services.AddScoped<CarService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

// Add the CreateDbIfNotExists method call
app.CreateDbIfNotExists();

app.MapGet("/", () => @"Car management API. Navigate to /swagger to open the Swagger test UI.");

app.Run();
