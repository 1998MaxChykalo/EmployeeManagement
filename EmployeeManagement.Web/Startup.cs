using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Infrastructure.Sql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Autofac;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using EmployeeManagement.Infrastructure.Sql.Models;
using AspNet.Security.OpenIdConnect.Server;
using AspNet.Security.OpenIdConnect.Primitives;
using AspNet.Security.OAuth.Validation;
using EmpMan.Helpers;
using EmployeeManagement.Web.Policies;
using EmployeeManagement.Infrastructure.Sql.Core;
using EmployeeManagement.Infrastructure.Sql.Core.Interfaces;
using AppPermissions = EmployeeManagement.Infrastructure.Sql.Core.ApplicationPermissions;
namespace EmpMan
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();
                    
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<EmployeeManagementDbContext>();

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<EmployeeManagementDbContext>()
                .AddDefaultTokenProviders();
            // var tokenProvider = new RsaJwtTokenProvider("issuer", "audience", "mykeyname");
            // services.AddSingleton<ITokenProvider>(tokenProvider);

            // services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //     .AddJwtBearer(options => {
            //         options.RequireHttpsMetadata = false;
            //         options.TokenValidationParameters = tokenProvider.GetValidationParameters();
            //     });

            // // This is for the [Authorize] attributes.
            // services.AddAuthorization(auth => {
            //     auth.DefaultPolicy = new AuthorizationPolicyBuilder()
            //         .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
            //         .RequireAuthenticatedUser()
            //         .Build();
            // });

            services.Configure<IdentityOptions>(options =>
            {
                // User settings
                options.User.RequireUniqueEmail = true;

                //    //// Password settings
                //    //options.Password.RequireDigit = true;
                //    //options.Password.RequiredLength = 8;
                //    //options.Password.RequireNonAlphanumeric = false;
                //    //options.Password.RequireUppercase = true;
                //    //options.Password.RequireLowercase = false;

                //    //// Lockout settings
                //    //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                //    //options.Lockout.MaxFailedAccessAttempts = 10;

                options.ClaimsIdentity.UserNameClaimType = OpenIdConnectConstants.Claims.Name;
                options.ClaimsIdentity.UserIdClaimType = OpenIdConnectConstants.Claims.Subject;
                options.ClaimsIdentity.RoleClaimType = OpenIdConnectConstants.Claims.Role;
            });

            services.AddOpenIddict(options =>
            {
                options.AddEntityFrameworkCoreStores<EmployeeManagementDbContext>();
                options.AddMvcBinders();
                options.EnableTokenEndpoint("/connect/token");
                options.AllowPasswordFlow();
                options.AllowRefreshTokenFlow();
                options.DisableHttpsRequirement();
                //options.AddSigningKey(new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(Configuration["STSKey"])));
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = OAuthValidationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OAuthValidationDefaults.AuthenticationScheme;
            }).AddOAuthValidation();

            services.AddSingleton(Configuration);
            
            services.AddScoped<IAccountManager, AccountManager>();
            
            // DB Creation and Seeding
            services.AddTransient<IDbInitializer, DbInitializer>();

            // Auth Policies
            services.AddSingleton<IAuthorizationHandler, ViewUserByIdHandler>();
            services.AddSingleton<IAuthorizationHandler, ManageUserByIdHandler>();
            services.AddSingleton<IAuthorizationHandler, ViewRoleByNameHandler>();
            services.AddSingleton<IAuthorizationHandler, AssignRolesHandler>();
            
            services.AddMvc()
            .AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            EmailSender.Configuration = new SmtpConfig
            {
                Host = Configuration["SmtpConfig:Host"],
                Port = int.Parse(Configuration["SmtpConfig:Port"]),
                UseSSL = bool.Parse(Configuration["SmtpConfig:UseSSL"]),
                Name = Configuration["SmtpConfig:Name"],
                Username = Configuration["SmtpConfig:Username"],
                EmailAddress = Configuration["SmtpConfig:EmailAddress"],
                Password = Configuration["SmtpConfig:Password"]
            };
            
            services.AddAuthorization(options =>
            {
                options.AddPolicy(AuthPolicies.ViewUserByUserIdPolicy, policy => policy.Requirements.Add(new ViewUserByIdRequirement()));

                options.AddPolicy(AuthPolicies.ViewUsersPolicy, policy => policy.RequireClaim(CustomClaimTypes.Permission, AppPermissions.ViewUsers));

                options.AddPolicy(AuthPolicies.ManageUserByUserIdPolicy, policy => policy.Requirements.Add(new ManageUserByIdRequirement()));

                options.AddPolicy(AuthPolicies.ManageUsersPolicy, policy => policy.RequireClaim(CustomClaimTypes.Permission, AppPermissions.ManageUsers));

                options.AddPolicy(AuthPolicies.ViewRoleByRoleNamePolicy, policy => policy.Requirements.Add(new ViewRoleByNameRequirement()));

                options.AddPolicy(AuthPolicies.ViewRolesPolicy, policy => policy.RequireClaim(CustomClaimTypes.Permission, AppPermissions.ViewRoles));

                options.AddPolicy(AuthPolicies.AssignRolesPolicy, policy => policy.Requirements.Add(new AssignRolesRequirement()));

                options.AddPolicy(AuthPolicies.ManageRolesPolicy, policy => policy.RequireClaim(CustomClaimTypes.Permission, AppPermissions.ManageRoles));
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new EmployeeManagement.IoC.DefaultModule()); //For Autofac injection.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            EmailTemplates.Initialize(env);

            //Configure Cors
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}