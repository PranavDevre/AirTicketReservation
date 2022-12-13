using AIR_RESERVATION_SYSTEM_API.Context;
using AIR_RESERVATION_SYSTEM_API.Logging;
using AIR_RESERVATION_SYSTEM_API.Repository;
using AIR_RESERVATION_SYSTEM_API.Token;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AIR_RESERVATION_SYSTEM_API
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
            string serverconnection = this.Configuration.GetConnectionString("localsqlconnection");
            services.AddDbContext<AIRDbContext>(option => option.UseSqlServer(serverconnection));
            // services.AddControllersWithViews();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IFlightMaster, FlightMasterRepository>();
            services.AddSingleton<Admin_Logger>();
            //    services.AddControllersWithViews(p => p.Filters.Add(new logfilterattribute()));
            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AIR_RESERVATION_SYSTEM_API", Version = "v1" });

                #region Authorization

                //    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //    {
                //        In = ParameterLocation.Header,
                //        Description = "Please enter token",
                //        Name = "Authorization",
                //        Type = SecuritySchemeType.Http,
                //        BearerFormat = "JWT",
                //        Scheme = "bearer"
                //    });
                //    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                //    {
                //        {
                //            new OpenApiSecurityScheme
                //            {
                //                Reference = new OpenApiReference
                //                {
                //                    Type=ReferenceType.SecurityScheme,
                //                    Id="Bearer"
                //                }
                //            },
                //            new string[]{}
                //        }
                //    });
                #endregion

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AIR_RESERVATION_SYSTEM_API v1"));
            }


            app.UseHttpsRedirection();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseRouting();
            app.UseAuthorization();







            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
