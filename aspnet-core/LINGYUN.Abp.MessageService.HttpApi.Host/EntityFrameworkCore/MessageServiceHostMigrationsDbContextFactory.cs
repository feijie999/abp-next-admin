﻿using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LINGYUN.Abp.MessageService.EntityFrameworkCore
{
    public class MessageServiceHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<MessageServiceHostMigrationsDbContext>
    {
        public MessageServiceHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<MessageServiceHostMigrationsDbContext>()
                .UseMySql(configuration.GetConnectionString("Default"));

            return new MessageServiceHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json", optional: false);

            return builder.Build();
        }
    }
}
