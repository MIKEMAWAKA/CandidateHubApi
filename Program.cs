using CandidateHubApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CandidateDataContext>(

    options => options.UseInMemoryDatabase("CandidatesDb")
    );

//for using my sql database
//builder.Services.AddDbContext<CandidateDataContext>(options =>
//  options.UseMySql(builder.Configuration.GetConnectionString("RazorPagesDemoConnectionString"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("RazorPagesDemoConnectionString")))

//);

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
