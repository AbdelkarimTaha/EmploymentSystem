using Microsoft.OpenApi.Models;

namespace Presentation.Extensions;

public static class SwaggerServiceExtensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Book Management API",
                Version = "v1",
                Description = "API documentation for the Book Management System",
                Contact = new OpenApiContact
                {
                    Name = "Your Name",
                    Email = "your-email@example.com"
                }
            });
        });

        return services;
    }

    public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Book Management API V1");
            options.RoutePrefix = string.Empty; 
        });

        return app;
    }
}
