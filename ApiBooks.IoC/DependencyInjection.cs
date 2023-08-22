using ApiBooks.Application.Mappings;
using ApiBooks.Application.Services;
using ApiBooks.Application.Services.Interfaces;
using ApiBooks.Domain.Authentication;
using ApiBooks.Domain.Entities;
using ApiBooks.Domain.Repositories;
using ApiBooks.Infra.Authentication;
using ApiBooks.Infra.Context;
using ApiBooks.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiBooks.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastruture(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BooksDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DfCon")));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookImageRepository, BookImageRepository>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDtoMapping));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBookImageService, BookImageService>();
            return services;
        }

    }
}
