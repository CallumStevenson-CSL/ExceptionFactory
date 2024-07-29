using Microsoft.AspNetCore.Diagnostics;

namespace ExceptionFactory.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        builder.Services.AddControllers(options =>
        {
            if (!builder.Environment.IsDevelopment())
            {
                // options.Filters.Add<CustomExceptionFilter>();
            }
        });
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var exception = context.Features.Get<IExceptionHandlerPathFeature>();

                    if (exception?.Error is not null)
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "text/plain";
                        await context.Response.WriteAsync("Whoops something went wrong!");                        
                        
                        Console.WriteLine(exception.Error.Message);
                    }
                });
            });
        }
        
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
    }
}