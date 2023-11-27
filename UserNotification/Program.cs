using Microsoft.AspNetCore.SignalR;
using UserNotification;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSignalR();


builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseRouting();


app.MapPost("broadcast", async (string message, IHubContext<NotificationsHub, INotification> context) =>
{
    await context.Clients.All.RecieveNotification(message);

    return Results.NoContent();
});

app.MapHub<NotificationsHub>("notifications-hub");


app.Run();
