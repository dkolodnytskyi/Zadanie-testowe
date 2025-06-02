using FluentValidation;
using Mapster;
using ZadanieTestowe;
using ZadanieTestowe.Dtos;
using ZadanieTestowe.ExceptionHandlers;
using ZadanieTestowe.Services;
using ZadanieTestowe.Services.Interfaces;
using ZadanieTestowe.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<ICampaignService, CampaignService>();
builder.Services.AddScoped<IHelperService, HelperService>();
builder.Services.AddScoped<IValidator<CampaignDto>, CampaignValidator>();
builder.Services.AddExceptionHandler<ValidationExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddMapster();
builder.Services.AddCors(x => x.AddDefaultPolicy(y =>
{
    y.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();