using App1.ApiService.Application.Module1.Create;
using App1.ApiService.Application.Module1.Delete;
using App1.ApiService.Application.Module1.Get;
using App1.ApiService.Application.Module1.Update;

namespace App1.ApiService.Infrastructure.Extensions;

public static class Module1sExtensions
{
    public static WebApplicationBuilder AddModule1s(this WebApplicationBuilder builder)
    {
        builder.AddGet();
        builder.AddCreate();
        builder.AddUpdate();
        builder.AddDelete();
        return builder;
    }

    private static WebApplicationBuilder AddGet(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<GetModule1Handler>();
        return builder;
    }

    private static WebApplicationBuilder AddCreate(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<CreateModule1sHandler>();
        return builder;
    }

    private static WebApplicationBuilder AddUpdate(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<UpdateModule1sHandler>();
        return builder;
    }

    private static WebApplicationBuilder AddDelete(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<DeleteModule1sHandler>();
        return builder;
    }
}
