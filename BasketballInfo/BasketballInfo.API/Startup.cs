using AutoMapper;
using BasketballInfo.Application.Contract;
using BasketballInfo.Application.Profiles;
using BasketballInfo.Infrastructure.DbContexts;
using BasketballInfo.Infrastructure.Services;
using BasketballInfo.Infrastructure.Services.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BasketballInfo.API
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

            services.AddControllers().AddNewtonsoftJson(options =>
                     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BasketballInfo.API", Version = "v1" });
            });

            //services.AddTransient<ITeamContract, TeamContract>();
            //services.AddTransient<IPlayerContract, PlayerContract>();
            //services.AddTransient<ICoachContract, CoachContract>();
            services.AddTransient<IUserContract, UserContract>();

            services.AddDbContext<BasketballInfoContext>(opt => opt.UseSqlServer(Configuration["ConnectionStrings:BasketballInfoDBConnectionStringSqlServer"]));

            services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<ITeamRepository, TeamRepository>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TeamProfile());
                mc.AddProfile(new PlayerProfile());
                mc.AddProfile(new CoachProfile());
                mc.AddProfile(new UserProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BasketballInfo.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
