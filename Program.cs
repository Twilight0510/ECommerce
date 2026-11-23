using ECommerce.Data;
using Microsoft.EntityFrameworkCore;
using ECommerce.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký dịch vụ MVC vào Dependency Injection Container
builder.Services.AddControllersWithViews();

// Đọc Connection String từ appsettings.json
var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection");

// Đăng ký DbContext và SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Đăng ký ASP.NET Core Identity
builder.Services
    .AddIdentity<ApplicationUser, IdentityRole>(options =>
    {
        // Cấu hình mật khẩu
        options.Password.RequiredLength = 8;
        options.Password.RequireDigit = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = false;

        // Cấu hình email
        options.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Cấu hình Cookie đăng nhập
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

var app = builder.Build();

// Cấu hình xử lý lỗi khi chạy Production
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Chuyển hướng HTTP sang HTTPS
app.UseHttpsRedirection();

// Cho phép truy cập CSS, JS, hình ảnh trong wwwroot
app.UseStaticFiles();

// Kích hoạt Routing
app.UseRouting();

// Kích hoạt phân quyền
app.UseAuthorization();

// Cấu hình đường dẫn mặc định của MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Khởi chạy ứng dụng
app.Run();
