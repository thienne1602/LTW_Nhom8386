using LTW_Nhom8386.Repositories;
using ProductManagement.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Thêm MVC
builder.Services.AddControllersWithViews();

// Đăng ký Repository
builder.Services.AddScoped<IProductRepository, MockProductRepository>();
builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>(); // Thêm Category Repository

var app = builder.Build();

// Cấu hình Middleware
app.UseRouting();
app.UseStaticFiles();
app.UseAuthorization();
app.UseAuthentication(); // Nếu có xác thực

// Cấu hình Routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}"
);

app.Run();
