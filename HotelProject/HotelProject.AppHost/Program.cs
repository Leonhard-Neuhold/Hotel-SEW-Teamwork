var builder = DistributedApplication.CreateBuilder(args);

builder
    .AddProject<Projects.AuthenticationDuendeService>("duende");

builder
    .AddProject<Projects.Frontend>("frontend");

builder.Build().Run();