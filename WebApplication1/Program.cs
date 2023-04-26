//setting file

using WebApplication1.Controllers;

var builder = WebApplication.CreateBuilder(args);
//this builder object used as Main like in console.

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IDateServices, DateServicecs>();
builder.Services.AddTransient<IDateServices, NDateServicecs>();
//DI -loose coupling 
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
