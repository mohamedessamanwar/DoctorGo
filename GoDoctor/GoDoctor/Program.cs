using BusinessAccessLayer;
using DataAccessLayer;
using DataAccessLayer.Data.Context;
using DataAccessLayer.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GoDoctor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
             builder.Services.BusinessAccessLayer(builder.Configuration);
            builder.Services.DataAccessLayer(builder.Configuration);
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true; // Prevents client-side scripts from accessing the cookie
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Default expiration time for cookies
                options.SlidingExpiration = true; // Resets the expiration time on each request
            });

            builder.Services.AddDbContext<GoDoctorContext>(option => option.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<GoDoctorContext>();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
