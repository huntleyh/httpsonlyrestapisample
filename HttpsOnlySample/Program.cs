using static Microsoft.AspNetCore.Http.StatusCodes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpsRedirection(options =>
{
    // We are hosting a REST API so a redirect response is not appropriate
    // Instead, we will return a 400 Bad Request status code
    options.RedirectStatusCode = Status400BadRequest;
    options.HttpsPort = 5024; // Update HttpsPort as needed or use the appsettings.json to configure
});

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
