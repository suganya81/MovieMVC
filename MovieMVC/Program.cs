using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieMVC.Areas.Identity.Data;
using MovieMVC.Data;

namespace MovieMVC { 
    public class Program {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("MovieMVCContextConnection") ?? throw new InvalidOperationException("Connection string 'MovieMVCContextConnection' not found.");

            builder.Services.AddDbContext<MovieMVCContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<MovieMVCUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<MovieMVCContext>();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 0;
            });
            // Add services to the container.
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
            app.UseAuthentication(); ;

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "Admin", "Manager", "Member" };
                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
            using (var scope = app.Services.CreateScope())
            {
                var _userManager = scope.ServiceProvider.GetService<UserManager<MovieMVCUser>>();

                string email = "admin@admin.com";
                string password = "1234";

                if(await _userManager.FindByEmailAsync(email) == null)
                {
                    var user = new MovieMVCUser();
                    user.UserName = email;
                    user.Email = email;
                    await _userManager.CreateAsync(user, password);
                    await _userManager.AddToRoleAsync(user, "Admin");

                }

            } 
                app.Run();
        }
    }
}
