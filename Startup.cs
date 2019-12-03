using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using final_project;
using Microsoft.EntityFrameworkCore;
using final_project.Services;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using System.Security.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
 using Microsoft.IdentityModel.Tokens;
using final_project.Controllers;
namespace final_project
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Ecommerce")));
            services.AddControllersWithViews();
              services.AddScoped<IProductService,ProductService>();  
             services.AddScoped<ICategoryService,CategoryService>(); 
              services.AddScoped<IUserService,UserService>(); 
             services.AddMvc().AddNewtonsoftJson();
            services.AddMvc();
            services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = "JwtBearer";
            options.DefaultChallengeScheme = "JwtBearer";
        })
        .AddJwtBearer("JwtBearer", jwtOptions =>
        {
            jwtOptions.TokenValidationParameters = new TokenValidationParameters()
            {
                // The SigningKey is defined in the TokenController class
                IssuerSigningKey = TokenController.SIGNING_KEY,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromMinutes(5)
            };
        });
         
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:9000").AllowAnyHeader()
                                .AllowAnyMethod();
                });
            });

     
        //services.AddMvc();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {  if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
           app.UseCors(MyAllowSpecificOrigins); 
           //app.UseCors(options => options.AllowAnyOrigin());  
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();  // Must be before app.UseMvc
            //app.UseMvc();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            
        }
     

           
    }

}
