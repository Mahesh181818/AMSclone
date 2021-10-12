using AMS_BAL;
using AMS_Models.Models;
using AMS_Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagementSystem
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
            services.AddControllersWithViews();
            services.AddMvc();
            services.AddDbContext<ApartmentManagementContext>();
            services.AddScoped(typeof(Igeneric<>), typeof(GenericRepository<>));
            services.AddScoped<BAL_UserRegistration>();
            services.AddScoped<BAL_ServiceMaintainance>();
            services.AddScoped<BAL_Property>();
            services.AddScoped<BAL_Complaint>();
            services.AddScoped<BAL_Bill>();
            services.AddScoped<BAL_Announcement>();
            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            })


                .AddJwtBearer(opt =>
                {

                    opt.SaveToken = true;
                    opt.RequireHttpsMetadata = false;

                    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = "abc",
                        ValidAudience = "abc",

                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("abcdefghijklmnopqrst"))
                    };


                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                
            }
            /*app.UseHttpsRedirection();*/
            app.UseStaticFiles();

            app.UseRouting();
                //middleware
            app.UseSession();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern:
                    "{controller=Home}/{action=Index}/{id?}"
                    //"{controller=Home}/{action=LoginPageAdmin}/{id?}"
                    /*"{controller=UserRegistrationUI}/{action=showuserbyid}/{id?}"*/
                    // "{controller=ServiceMaintainanceUI}/{action=showservicedetails}/{id?}"

                    );
            });
        }
    }
}
