using System.Text;using System.Text.RegularExpressions;
using Domain;

Regex regex = new Regex(@"^\/test\/(?<data>.+?\/?.+)");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

var wrapper = new Wrapper();

    app.Run(async context =>

    {
        var match = regex.Match(context.Request.Path);
        if (match.Success)
            await context.Response.WriteAsync(wrapper.GetNumberPosition(match.Groups["data"].Value).ToString());
        else
            context.Response.StatusCode = 400;

    await Task.CompletedTask;

});

app.Run();
