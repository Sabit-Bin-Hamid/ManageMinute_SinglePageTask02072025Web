using Microsoft.EntityFrameworkCore;
using Single_Page_Task_02072025.Data;
using Single_Page_Task_02072025.Service.Interface;
using Single_Page_Task_02072025.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//DB Connection
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//DI Customer
builder.Services.AddScoped<IMeetingMinutes, MeetingMinutes>();
builder.Services.AddScoped<IMeetingMinutesService, MeetingMinutesService>();
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
    pattern: "{controller=MeetingAndProduct}/{action=Index}/{id?}");

app.Run();
