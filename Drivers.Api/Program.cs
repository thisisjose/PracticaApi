using Drivers.Api.Configurations;
using Drivers.Api.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//esto lo agg
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("MongoDatabase"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 


//Esto lo agg
builder.Services.AddSingleton<DriverService>(); //segundo agg

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
