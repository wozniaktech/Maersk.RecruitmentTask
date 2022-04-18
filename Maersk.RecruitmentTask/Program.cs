using Maersk.RecruitmentTask.Controllers;
using Maersk.RecruitmentTask.Helper;
using Maersk.RecruitmentTask.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IInMemBookingPriceRepository, InMemBookingPriceRepository>();
builder.Services.AddSingleton<ICurrencyHelper, CurrencyHelper>();
builder.Services.AddLogging();
builder.Services.AddSingleton(typeof(ILogger), typeof(Logger<BookingPriceController>));
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
