var builder = WebApplication.CreateBuilder(args);

// Add Services to container

builder.Services.AddCarter();
builder.Services.AddMediatR(connfig =>
{
    connfig.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

var app = builder.Build();

// Configure the Http request pipeline

app.MapCarter();

app.Run();
