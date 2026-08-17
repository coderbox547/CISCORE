using CisCore.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add MVC with Views
builder.Services.AddControllersWithViews();

// Register MailService for DI
builder.Services.AddScoped<IMailService, MailService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Conventional routing matching original RouteConfig
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
