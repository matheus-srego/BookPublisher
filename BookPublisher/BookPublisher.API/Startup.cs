using BookPublisher.Domain.Interfaces.Repositories;
using BookPublisher.Domain.Interfaces.Services;
using BookPublisher.Persistence.Context;
using BookPublisher.Persistence.Repositories;
using BookPublisher.Service.Services;
using Microsoft.EntityFrameworkCore;

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

            var connection = _configuration["ConnectionString:editora-db"];

            serviceCollection.AddDbContext<BookPublisherContext>(options => {

                options.UseSqlServer(connection);

            });
        }
    }
}
