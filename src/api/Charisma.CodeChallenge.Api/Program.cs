
var builder = WebApplication.CreateBuilder(args);
// Add serilog services
builder.Host.UseSerilog((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;

builder.Services.AddDbContext<OrderDbContext>(options =>
            options.EnableSensitiveDataLogging()
            .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add request log
builder.Services.AddHttpLogging(opts =>
{
    opts.LoggingFields = HttpLoggingFields.ResponseBody;
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    BaseAutofacConfig config;

    config = new DIConfig(containerBuilder, configuration);
    config.SetConfig();

});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add request log
app.UseHttpLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
