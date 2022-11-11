using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using PaystackSDK;

using Peadetfoods.Application.Common;
using Peadetfoods.Application.Repository;
using Peadetfoods.Domain.Entities;
using Peadetfoods.Infrastructure.Common;
using Peadetfoods.Infrastructure.Common.Database;
using Peadetfoods.Infrastructure.Repositories;

namespace Peadetfoods.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var migrationAssembly = typeof(DependencyInjection).Assembly.GetName().Name;
            services.AddIdentity<AppUser, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<MainContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<MainContext>(config =>
            {
                config.UseSqlServer(configuration.GetConnectionString("MainContext"), opts => opts.MigrationsAssembly(migrationAssembly));
            });

            services.AddAuthentication()
                .AddCookie();

            services.AddIdentityServer()
                .AddAspNetIdentity<AppUser>()
                .AddConfigurationStore(options =>
                {

                    options.ConfigureDbContext = b => b.UseSqlServer(configuration.GetConnectionString("MainContext"), sql => sql.MigrationsAssembly(migrationAssembly));
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = b => b.UseSqlServer(configuration.GetConnectionString("MainContext"), sql => sql.MigrationsAssembly(migrationAssembly));
                });

            services.AddPaystackSdk(configuration["Paystack:SecretKey"]);

            services.AddScoped(typeof(IBaseRepo<>), typeof(BaseRepo<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
