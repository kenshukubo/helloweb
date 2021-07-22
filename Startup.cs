// using helloweb.Common;
using System.Collections.Generic;
using System.Linq;
using helloweb.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using helloweb.Models.Interface;

namespace helloweb
{
    public class Startup{
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services){
            // MVCモジュールの導入
            // services.AddMvc ();
            services.AddMvc(option => option.EnableEndpointRouting = false);

            // DB接続コンテキスト
            services.AddDbContext<TutorialDbContext> (options =>
                options.UseSqlServer (Configuration.GetConnectionString ("tutorial_db"))
            );

            // リポジトリ
            services.AddTransient<TutorialRepository> ();

            // インターフェース
            services.AddTransient<IGreeting, GoodMorning> ();

            // リポジトリ
            // services.AddTransient<TutorialWithSqlRepository> ();
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

                // tutorial/welcome/dongsu/18
                routes.MapRoute (
                    name: "TutorialPathValueRoute",
                    template: "{controller}/{action}/{name}/{age}"
                );

                // 一項目のpath名は自由に指定して、defaultsでcontrollerを定義
                routes.MapRoute (
                    name: "ActionResultTest",
                    template: "art/{action}",
                    defaults : new { controller = "ActionResultTest" }
                );

                routes.MapRoute (
                    name: "ParamsMappingTest",
                    template: "pmt/{action}/{id?}",
                    defaults : new { controller = "ParamsMappingTest" }
                );
            });
        }
    }
}