﻿using BookPublisher.Domain.Interfaces.Repositories;
using BookPublisher.Domain.Interfaces.Services;
using BookPublisher.Persistence.Context;
using BookPublisher.Persistence.Repositories;
using BookPublisher.Service.Services;
using Microsoft.EntityFrameworkCore;
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

            // serviceCollection.AddScoped<IBookAuthorRepository, BookAuthorRepository>();

            var connection = _configuration["ConnectionString:editora-db"];

            serviceCollection.AddDbContext<BookPublisherContext>(options => {

                options.UseSqlServer(connection);

            });

            serviceCollection.AddControllers().AddJsonOptions(
                x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
            );
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("https://localhost:49159");
                });
    }
}
