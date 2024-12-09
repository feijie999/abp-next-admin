﻿using LINGYUN.Abp.UI.Navigation.VueVbenAdmin;
using Microsoft.Extensions.DependencyInjection;
#if POSTGRESQL
using LY.MicroService.Applications.Single.EntityFrameworkCore.PostgreSql;
#else
using LY.MicroService.Applications.Single.EntityFrameworkCore;
#endif
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace LY.MicroService.Applications.Single.DbMigrator;

[DependsOn(
    typeof(AbpUINavigationVueVbenAdminModule),
#if POSTGRESQL
    typeof(SingleMigrationsEntityFrameworkCorePostgreSqlModule),
#else
    typeof(SingleMigrationsEntityFrameworkCoreModule),
#endif
    typeof(AbpAutofacModule)
    )]
public partial class SingleDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        ConfigureTiming(configuration);
    }
}
