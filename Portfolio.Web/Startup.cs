using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Portfolio.Core.Interfaces.Repositories;
using Portfolio.Core.Interfaces.Repositories.Queries;
using Portfolio.Core.Interfaces.Services;
using Portfolio.Core.Services;
using Portfolio.Data.Identity;
using Portfolio.Data.Repositories;
using Portfolio.Data.Repositories.Queries;

namespace Portfolio
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
            services.AddDbContext<PortfolioIdentityDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("IdentityDbContextConnection"));
                })
                .AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<PortfolioIdentityDbContext>();
            
            services.AddSingleton<IMessageService, EmailService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IPaginationService, PaginationService>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IBlogCommandText, BlogBlogCommandText>();
            services.AddScoped<ISubscriberCommandText, SubscriberCommandText>();
            services.AddScoped<ISubscriberRepository, SubscriberRepository>();
            services.AddScoped<ISubscriberService, SubscriberService>();
            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
            });
            
            services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeFolder("/Admin");
            });

            services.AddServerSideBlazor();

            services.AddAuthorization();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
            });
        }
    }
}