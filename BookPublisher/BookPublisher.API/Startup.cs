using BookPublisher.Domain.Interfaces.Repositories;
using BookPublisher.Domain.Interfaces.Services;
using BookPublisher.Persistence.Context;
using BookPublisher.Persistence.Repositories;
using BookPublisher.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

namespace BookPublisher.API
{
    public class Startup
    {
        protected readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public virtual void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAuthorService, AuthorService>();
            serviceCollection.AddScoped<IAuthorRepository, AuthorRepository>();

            serviceCollection.AddScoped<IBookService, BookService>();
            serviceCollection.AddScoped<IBookRepository, BookRepository>();

            serviceCollection.AddScoped<IBookAuthorService, BookAuthorService>();
            serviceCollection.AddScoped<IBookAuthorRepository, BookAuthorRepository>();

            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();

            var connection = _configuration["ConnectionString:editora-db"];

            serviceCollection.AddDbContext<BookPublisherContext>(options => {

                options.UseSqlServer(connection);

            });
            // Descerializar objetos JSON cíclicos
            serviceCollection.AddControllers().AddJsonOptions(
                x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
            );

            var secretKey = "ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE";

            serviceCollection.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }

        /*public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("https://localhost:49159");
                });*/
    }
}
