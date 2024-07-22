var builder = DistributedApplication.CreateBuilder(args);

var apiservice = builder.AddProject<Projects.AspireAppAPIService>("apiservice");
builder.AddProject<Projects.AspireWebApp>("webfrontend").WithReference(apiservice);


builder.Build().Run();
