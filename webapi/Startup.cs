using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using webapi.Data;
using webapi.DataAccess;
using Oracle.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using MongoDB.Driver;



namespace webapi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAuthorization();

            // Fetch the Oracle connection string from appsettings.json
            string oracleConnectionString = Configuration.GetConnectionString("OracleConnection");
            services.AddDbContext<Microsoft.EntityFrameworkCore.DbContext>(options =>
                options.UseOracle(oracleConnectionString));

            services.AddScoped<DataAccess.DataAccess>(); // Register DataAccess.DataAccess as a scoped service

            services.AddScoped<ExcelDataReader>();
            services.AddScoped<CombineDataHandler>();

            // MongoDB configuration
            var mongoSettings = Configuration.GetSection("MongoDB");
            services.AddSingleton(new MongoDataAccess(
                mongoSettings["ConnectionString"],
                mongoSettings["DatabaseName"]
            ));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin", builder =>
                {
                    builder.WithOrigins("http://localhost:3000") // Note: using http here
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors("AllowOrigin"); // Use the correct policy name


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


    }
}
