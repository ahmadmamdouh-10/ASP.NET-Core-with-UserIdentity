using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class ITIDBContextFactory
        : IDesignTimeDbContextFactory<ITIDBContext>
    {
        public ITIDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot SettingsObj 
                = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            DbContextOptionsBuilder<ITIDBContext>
                 Builder
                 = new DbContextOptionsBuilder<ITIDBContext>();
            Builder.UseSqlServer(SettingsObj.GetConnectionString("ITPSohagDotNet"));

            ITIDBContext Context
                = new ITIDBContext(Builder.Options);
            return Context;
        }
    }
}
