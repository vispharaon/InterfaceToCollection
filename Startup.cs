using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterfaceToCollection.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace InterfaceToCollection
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
            services
                .AddCors()
                .AddMvc(options =>
                {
                    options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var connection = @"Server=den1.mssql7.gear.host;Database=customcollection;User Id=customcollection;PWD=Ob9J__6p9ta9;Trusted_Connection=False;ConnectRetryCount=0";
            services.AddDbContext<CustomcollectionContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Shows UseCors with CorsPolicyBuilder.
            app.UseCors(builder => builder
                                          .AllowAnyHeader()
                                          .AllowAnyMethod()
                                          .AllowAnyOrigin()
                                          .AllowCredentials()
                      );

            app.UseMvc();

        }
    }
}
