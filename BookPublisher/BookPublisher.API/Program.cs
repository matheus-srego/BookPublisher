using BookPublisher.API;
using BookPublisher.Domain.Constants;

var MyAllowSpecificOrigins = CONFIGURATION.SPECIFIC_ORIGIN;

var builder = WebApplication.CreateBuilder(args);

/*builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("https://localhost:7272/");
        });
});*/

builder.WebHost.ConfigureKestrel(options => {
    options.ListenAnyIP(4001);
});

IConfiguration configuration = builder.Configuration;

var startup = new Startup(configuration);
startup.ConfigureServices(builder.Services);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
