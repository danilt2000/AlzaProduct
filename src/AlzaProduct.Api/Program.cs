using AlzaProduct.Api.SwaggerConfig;
using AlzaProduct.BindingsProvider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AlzaProduct.Api;

internal class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Configuration.AddEnvironmentVariables();

#if RELEASE
        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.ListenAnyIP(80);
        });
#endif

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(с =>
        {
            с.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "AlzaProduct.Api v1",
                Version = "v1",
                Description = "API version 1.0"
            });

            с.SwaggerDoc("v2", new OpenApiInfo
            {
                Title = "AlzaProduct.Api v2",
                Version = "v2",
                Description = "API version 2.0 with pagination"
            });
        });

        builder.Services.AddRouting();

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(corsPolicyBuilder =>
            {
                corsPolicyBuilder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        builder.Services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
        });

        builder.Services.AddVersionedApiExplorer(options =>
        {
            options.SubstituteApiVersionInUrl = true;
        });

        builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerConfigOptions>();

        builder.Services.AddAlzaProduct(builder.Configuration);

        var app = builder.Build();

        var versionDescProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

        app.UseSwagger();

        app.UseSwaggerUI(options =>
        {
            foreach (var desc in versionDescProvider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{desc.GroupName}/swagger.json", $"Alza Product - {desc.GroupName.ToUpper()}");
            }
        });

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseForwardedHeaders();

        app.UseCors(k =>
        {
            k.WithMethods("POST", "GET", "PATCH", "PUT");
            k.AllowAnyOrigin();
            k.AllowAnyHeader();
        });

        app.MapDefaultControllerRoute().AllowAnonymous();
        app.MapSwagger();
        app.MapControllers().AllowAnonymous();

        app.Run();
    }
}
