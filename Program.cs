using ECommerceFrontend.Components;
using ECommerceFrontend.Models;
using ECommerceFrontend.Services;
using Microsoft.EntityFrameworkCore;

namespace ECommerceFrontend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddScoped<ProductServices>();
            builder.Services.AddScoped<UserServices>();
            builder.Services.AddScoped<LoggingService>();
            builder.Services.AddScoped<emailSendingService>();
            builder.Services.AddScoped<ReviewServices>();
            builder.Services.AddScoped<OrderServices>();
            builder.Services.AddScoped<OrderProductServices>();
            builder.Services.AddScoped<JwtService>();
            builder.Services.AddScoped<AuthServices>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
