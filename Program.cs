using Backend.Data;
using Backend.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ITransactionBpkbRepository, TransactionBpkbRepository>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyWorldDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));

});



//services cors
builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(
      options => options.WithOrigins("https://localhost:7131").AllowAnyMethod().AllowAnyHeader()
  );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
