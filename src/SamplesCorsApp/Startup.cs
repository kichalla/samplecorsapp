using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Cors.Core;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;

namespace SamplesCorsApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddMvc();

            services.ConfigureCors(o =>
            {
                var policy = new CorsPolicy();
                policy.Origins.Add("http://localhost:5001");
                o.AddPolicy("policy1", policy);
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
