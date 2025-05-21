var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.FirstDemo_API>("api");

var web = builder.AddProject<Projects.FirstDemo_BLazor_Server>("server")
    .WithReference(api)
    .WithExternalHttpEndpoints();

builder.Build().Run();
