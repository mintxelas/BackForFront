var builder = DistributedApplication.CreateBuilder(args);
builder.AddProject<Projects.Idsrv4>("idp");
builder.AddProject<Projects.FrontApi>("front");
builder.AddProject<Projects.InternalApi>("back");
builder.Build().Run();