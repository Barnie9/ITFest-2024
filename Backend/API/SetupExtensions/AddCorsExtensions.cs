using API.Constants;

namespace API.SetupExtensions;

public static class AddCorsExtensions
{
    public static IServiceCollection AddCorsExtension(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                policy =>
                {
                    policy.WithOrigins(EnvironmentVariables.CorsOrigin)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
        });
}