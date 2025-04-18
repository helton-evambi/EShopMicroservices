var builder = WebApplication.CreateBuilder(args);

// Add Services to container

builder.Services.AddCarter();
builder.Services.AddMediatR(connfig =>
{
    connfig.RegisterServicesFromAssembly(typeof(Program).Assembly);
    connfig.AddOpenBehavior(typeof(ValidationBehavior<,>));
    connfig.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

if (builder.Environment.IsDevelopment())
    builder.Services.InitializeMartenWith<CatalogInitialData>();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

// Configure the Http request pipeline

app.MapCarter();

app.UseExceptionHandler(options => { });

app.Run();
