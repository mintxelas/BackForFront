var builder = DistributedApplication.CreateBuilder(args);

var idp = builder.AddProject<Projects.Idsrv4>("idp")
    .WithHttpsEndpoint(port: 5100);

var back = builder.AddProject<Projects.InternalApi>("back")
    .WithHttpsEndpoint(port: 5300)
    .WithReference(idp);

var front = builder.AddProject<Projects.FrontApi>("front")
    .WithHttpsEndpoint(port: 5200)
    .WithReference(idp)
    .WithReference(back);

idp.WithReference(front).WithReference(back);

builder.Build().Run();