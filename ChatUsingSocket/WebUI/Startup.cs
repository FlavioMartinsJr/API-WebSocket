using Infrastructure.IOC;
using WebUI.MappingConfig;
using WebUI.Handlers;
using WebUI.Manager;
using WebUI.Middlewares;

namespace WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ConnectionManager>();
            services.AddSingleton<ChatHandler>();
            services.AddAutoMapperConfiguration();  
            services.AddRazorPages();
            services.AddControllersWithViews();
            services.AddInfrastructure(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ChatHandler handler)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors(option => option.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());


            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Login}/{action=Index}"
                     );
                }
            );

            var webSocketOptions = new WebSocketOptions()
            {
                KeepAliveInterval = TimeSpan.FromSeconds(120),
                ReceiveBufferSize = 4 * 1024
            };
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseWebSockets(webSocketOptions);
            app.UseMiddleware<WebSocketMiddleware>(handler);

        }
       
    }
}
