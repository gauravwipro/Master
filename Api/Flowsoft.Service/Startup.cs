using Flowsoft.Data;
using Flowsoft.DataServices.Interfaces;
using Flowsoft.DataServices.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Flowsoft.Repository.interfaces;
using Flowsoft.Repository.repositories;
using Flowsoft.Domain.Models;

namespace Flowsoft.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddCors(o => o.AddPolicy("CORS", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            byte[] key = this.GetTokenSecretKey(services);
            RegisterDatabase(services);
            services.AddAuthentication((Action<AuthenticationOptions>)(x =>
            {
                x.DefaultAuthenticateScheme = "Bearer";
                x.DefaultChallengeScheme = "Bearer";
            })).AddJwtBearer((Action<JwtBearerOptions>)(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = (SecurityKey)new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            }));
            RegisterServices(services);
            RegisterRepositories(services);
            services.AddSwaggerGen((Action<SwaggerGenOptions>)(c =>
            {
                c.SwaggerDoc("v1", new Info()
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = "None",
                    Contact = new Contact()
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty,
                        Url = "https://twitter.com/spboyer"
                    },
                    License = new License()
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license"
                    }
                });
                string filePath = Path.Combine(AppContext.BaseDirectory, Assembly.GetExecutingAssembly().GetName().Name + ".xml");
                c.IncludeXmlComments(filePath, false);
            }));
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IPatientAdmissionRepository, PatientAdmissionRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<IOpdRepository, OpdRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        private void RegisterDatabase(IServiceCollection services)
        {
            IConfigurationSection section = this.Configuration.GetSection("ConnectionStrings");
            services.Configure<AppSettings>((IConfiguration)section);
            string connection = section.Get<ConnectionStrings>().HmsDatabase;
            services.AddDbContext<EcomContext>((Action<DbContextOptionsBuilder>)(options => options.UseSqlServer(connection, (Action<SqlServerDbContextOptionsBuilder>)null)), ServiceLifetime.Scoped, ServiceLifetime.Scoped).AddUnitOfWork<EcomContext>(); 
        }

        private byte[] GetTokenSecretKey(IServiceCollection services)
        {
            IConfigurationSection section = this.Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(section);
            return Encoding.ASCII.GetBytes(section.Get<AppSettings>().Secret);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDataContext, EcomContext>();

            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IPatientAdmissionService, PatientAdmissionService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<IOpdService, OpdService>();
            services.AddScoped<IOpdService, OpdService>();
            services.AddScoped<IUnitOfWork, UnitOfWork<EcomContext>>();


           
            
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseCors("CORS");
            app.UseAuthentication();
            app.UseMvc();
            app.UseStaticFiles();
            app.UseSwagger((Action<SwaggerOptions>)null);
            app.UseSwaggerUI((Action<SwaggerUIOptions>)(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Flowsoft HMS service");
                c.RoutePrefix = string.Empty;
            }));
           
        }
    }
}
