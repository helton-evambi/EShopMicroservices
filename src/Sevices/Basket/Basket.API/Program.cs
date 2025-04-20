var builder = WebApplication.CreateBuilder(args);

//Add services to the container

var app = builder.Build();

//Configute the HTTP request pipelline

app.Run();
