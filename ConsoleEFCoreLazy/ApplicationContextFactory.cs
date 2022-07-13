﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEFCoreLazy
{
    public sealed class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            //var connectionString = Environment.GetEnvironmentVariable("EFCORETOOLSDB");
            var connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Application;Integrated Security=True";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionString)
                .Options;

            return new ApplicationContext(options);
        }
    }
}
