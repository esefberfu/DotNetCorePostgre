﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
using DotNetCorePostgre.Context;

namespace DotNetCorePostgre
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            var connectionString = Configuration["PostgreSql:ConnectionString"];
            var dbPassword = Configuration["PostgreSql:DbPassword"];
            
            var builder = new Npgsql.NpgsqlConnectionStringBuilder(Configuration.GetConnectionString("ConnectionStringsPostgresql"))
            {
                Host = "85.95.241.63",
                Password = "test123ASD!",
                Port = 5432,
                Database = "test_1",
                Username = "postgres",
            };

            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(builder.ConnectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
