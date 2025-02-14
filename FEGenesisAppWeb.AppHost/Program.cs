var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.FEGenesisAppWeb_ApiService>("apiservice");

builder.AddProject<Projects.FEGenesisAppWeb_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
