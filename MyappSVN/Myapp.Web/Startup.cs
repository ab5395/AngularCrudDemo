using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Myapp.Data;
using Myapp.Data.Dto;

namespace Myapp.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);
                options.LoginPath = "/Account/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                options.LogoutPath = "/Account/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
                options.AccessDeniedPath = "/Account/AccessDenied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                options.SlidingExpiration = true;
            });

            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //  .AddJwtBearer(x =>
            //  {
            //      x.RequireHttpsMetadata = false;
            //      x.SaveToken = true;
            //      x.TokenValidationParameters = new TokenValidationParameters
            //      {
            //          ValidateIssuerSigningKey = true,
            //          IssuerSigningKey = new SymmetricSecurityKey(SymmetricSecurityKey),
            //          ValidateIssuer = false,
            //          ValidateAudience = false
            //      };
            //  });

            //services.AddAuthorization(options =>
            //{
            //    options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build();
            //});

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<ContextInitializer>();

            //services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            //services.Configure<GoogleApiCreds>(Configuration.GetSection("GoogleApiCreds"));

            //services.AddTransient<EmailService>();
            //services.AddTransient<GoogleApiCreds>();

            //services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddScoped<IUserManagementRepository, UserManagementRepository>();
            //services.AddScoped<ISecurityQuestionRepository, SecurityQuestionRepository>();
            //services.AddScoped<ILocationRepository, LocationRepository>();
            //services.AddScoped<ICompanyRepository, CompanyRepository>();
            //services.AddScoped<IGoogleServicesRepository, GoogleServicesRepository>();
            //services.AddScoped<IModelAgentProfileRepository, ModelAgentProfileRepository>();

            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ContextInitializer seeder)
        {

            var options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("index.html");

            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                {
                    context.Request.Path = "wwwroot/index.html";
                    await next();
                }
            })
            .UseCors("AllowAll")
            .UseMvc()
            .UseDefaultFiles(options)
            .UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            seeder.Seed().Wait();

            //app.UseHttpsRedirection();
            //app.UseMvc();
        }
    }
}
