using Microsoft.Extensions.Hosting;
using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache")
                   .WithRedisInsight(s => s.WithLifetime(ContainerLifetime.Persistent))
                   .WithLifetime(ContainerLifetime.Persistent)
                   .WithDataVolume("App1-cache");

var sqlServer = builder.AddSqlServer("sqlserver")
                       .WithLifetime(ContainerLifetime.Persistent)
                       .WithDataVolume("App1-database");

var database = sqlServer.AddDatabase("database", "App1");

var apiService = builder.AddProject<App1_ApiService>("apiservice")
                        .WithReference(database)
                        .WaitFor(database)
                        .WithReference(cache)
                        .WaitFor(cache);

builder.AddProject<App1_WebApp>("webfrontend")
       .WithExternalHttpEndpoints()
       .WithReference(apiService)
       .WaitFor(apiService)
       .WithReference(cache)
       .WaitFor(cache);

if (!builder.Environment.IsDevelopment())
{
	var serviceBus = builder.AddRabbitMQ("servicebus")
	                        .WithManagementPlugin()
	                        .WithLifetime(ContainerLifetime.Persistent)
	                        .WithDataVolume("App1-servicebus");

	apiService.WithReference(serviceBus);
}

await builder.Build().RunAsync();