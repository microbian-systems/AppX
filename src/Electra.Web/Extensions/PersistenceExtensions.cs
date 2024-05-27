﻿using Electra.Common.Caching.Decorators;
using Electra.Core.Identity;
using Electra.Models;
using Electra.Persistence;

namespace Electra.Common.Web.Extensions;

public static class PersistenceExtensions
{
    public static IServiceCollection AddDataLayerPersistence<T>(this IServiceCollection services, IConfiguration config, IWebHostEnvironment host)
        where T : DbContext
    {
        var sp = services.BuildServiceProvider();
        var log = sp.GetRequiredService<ILogger<object>>();

        log.LogInformation($"Adding data later persistence rules");

        services.AddDbContext<ElectraDbContext>(o =>
            o.UseSqlite(
                config.GetConnectionString("sqlite"),
                x => x.MigrationsHistoryTable("__ElectraMigrations", "electra")
                    .MigrationsAssembly(typeof(ElectraDbContext).Assembly.FullName)
                    .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
        services.AddDbContext<ElectraDbContext<ElectraUser, ElectraRole>>(o =>
            o.UseSqlite(
                config.GetConnectionString("sqlite"),
                x => x.MigrationsHistoryTable("__ElectraMigrations", "electra")
                    .MigrationsAssembly(typeof(ElectraDbContext).Assembly.FullName)
                    .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

        log.LogInformation($"configuring generic repositories");
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericEntityFrameworkRepository<>));
        services.AddScoped(typeof(IGenericEntityFrameworkRepository<>), typeof(GenericEntityFrameworkRepository<>));
        services.AddScoped(typeof(IGenericEntityFrameworkRepository<,>), typeof(GenericEntityFrameworkRepository<,>));
        services.AddScoped(typeof(ICachingRepositoryDecorator<,>), typeof(CachingRepository<,>));
        services.AddScoped(typeof(ICachingRepositoryDecorator<>), typeof(CachingRepository<>));

        return services;
    }

    public static IServiceCollection AddDataLayerPersistence(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment host)
        => AddDataLayerPersistence<ElectraDbContext>(services, configuration, host);
}