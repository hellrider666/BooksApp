using BookApp.WebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.AddWebApplicationBuilder();
builder.Services.AddAppServices(builder);

var app = builder.Build();

app.AddWebApplication();
