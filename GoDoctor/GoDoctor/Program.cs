using BusinessAccessLayer;
using BusinessAccessLayer.Hubs;
using BusinessAccessLayer.Services.Email;
using DataAccessLayer;
using DataAccessLayer.Data.Context;
using DataAccessLayer.Data.Models;
using DataAccessLayer.Repositories.SpecialtyRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using NToastNotify;

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
            builder.Services.Configure<MailSetting>(builder.Configuration.GetSection("MailSetting"));

            builder.Services.AddDbContext<GoDoctorContext>(option => option.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<GoDoctorContext>().AddEntityFrameworkStores<GoDoctorContext>()
               .AddDefaultTokenProviders(); 
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
            builder.Services.AddSignalR();
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
            builder.Services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
            {
                ProgressBar = true,
                PositionClass = ToastPositions.TopRight,
                PreventDuplicates = true,
                CloseButton = true
            });
            builder.Services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();
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
            app.MapHub<CommentHub>("/commentHub");
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
