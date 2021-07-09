using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace helloweb
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services){
            // MVCモジュールの導入
            // services.AddMvc ();
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env){
            if (env.IsDevelopment()){
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc (routes => {
                // デフォルトルートの設定
                routes.MapRoute (
                    name: "Default",
                    template: "{controller}/{action}",
                    defaults : new { controller = "Home", action = "Index" }
                );

                routes.MapRoute (
                    name: "TutorialPathValueRoute",
                    template: "{controller}/{action}/{name}/{age}"
                );

                routes.MapRoute (
                    name: "ActionResultTest",
                    template: "art/{action}",
                    defaults : new { controller = "ActionResultTest" }
                );
            });
        }
    }
}