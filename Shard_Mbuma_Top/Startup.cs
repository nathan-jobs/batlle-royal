using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shard.Shared.Core;

namespace Shard_Mbuma_Top
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            var count = 1;
            var count2 = 1;
            var map = new MapGenerator(new MapGeneratorOptions());
            var sector = map.Generate();

            foreach(SystemSpecification res in sector.Systems)
            {
                Console.WriteLine($"{res.Name}, Mouss");
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    foreach (SystemSpecification res in sector.Systems)
                    {
                        await context.Response.WriteAsync($"System #{count} : {res.Name}\n");
                        foreach (PlanetSpecification res2 in res.Planets)
                        {
                            await context.Response.WriteAsync($"    Planet #{count2} : {res2.Name}\n");
                            count2++;
                        }
                        count++;
                        count2 = 0;
                    }
                });

                endpoints.MapGet("/planets", async context =>
                {
                    await context.Response.WriteAsync("......");
                });
            });
        }



    }
}
