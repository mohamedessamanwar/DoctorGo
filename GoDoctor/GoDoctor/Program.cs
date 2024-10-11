using BusinessAccessLayer;
using DataAccessLayer;
using DataAccessLayer.Data.Context;
using DataAccessLayer.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

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
                options.ExpireTimeSpan = TimeSpan.FromMinutes(3); // Default expiration time for cookies
                options.SlidingExpiration = true; // Resets the expiration time on each request
            });
            
            builder.Services.AddDbContext<GoDoctorContext>(option => option.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<GoDoctorContext>();
            builder.Services.ConfigureApplicationCookie(options =>
            {
                // Redirect to login page when not authenticated
                options.LoginPath = "/Auth/Login";

                // Redirect to access denied page when not authorized
                options.AccessDeniedPath = "/Auth/Login";
            });
            builder.Services.AddControllersWithViews();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("https://localhost:44326") // Specify your frontend origin
                                      .AllowAnyHeader()
                                      .AllowAnyMethod()
                                      .AllowCredentials());
            });
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                {
                    policy.RequireRole("Admin");  // Specify the role(s) for this policy
                });
                options.AddPolicy("Patient", policy =>
                {
                    policy.RequireRole("Patient");  // Specify the role(s) for this policy
                });
                options.AddPolicy("Doctor", policy =>
                {
                    policy.RequireRole("Doctor");  // Specify the role(s) for this policy
                });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowSpecificOrigin"); // Use the CORS policy
           // app.UseMiddleware<GlobalError>();
            app.UseStaticFiles();
       
            var staticFilesPath = Path.Combine(Environment.CurrentDirectory, "wwwroot", "Img", "Doctors");
        
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(staticFilesPath),
        
                RequestPath = "/Images/Doctor"
            });
       
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
