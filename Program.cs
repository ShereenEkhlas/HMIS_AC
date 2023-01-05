using HMIS_AC.Data;
using HMIS_AC.IServices;
using HMIS_AC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("hmisConnection") ?? throw new InvalidOperationException("Connection string 'hmisConnection' not found.");

builder.Services.AddDbContext<HMIS_ACContext>(options =>
    options.UseSqlServer(connectionString)); ;

//builder.Services.AddDefaultIdentity<IdentityUser>(options => {


//    options.SignIn.RequireConfirmedAccount = false;
//    options.Password.RequireDigit = false;
//    options.Password.RequiredLength = 6;
//    options.Password.RequireNonAlphanumeric = false;
//    options.Password.RequireUppercase = false;
//    options.Password.RequireLowercase = false;


//})
//    .AddEntityFrameworkStores<HMIS_ACContext>();



//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));




builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<HMIS_ACContext>();
builder.Services.AddControllersWithViews();


//Define connection String
IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

//Inject Db Context
builder.Services.AddDbContext<HMISContext>(option => option.UseSqlServer(configuration.GetConnectionString("hmisConnection")));


//Inject Services
builder.Services.AddTransient(typeof(IBaseService<Patient>), typeof(PatientService));
builder.Services.AddTransient(typeof(IBaseService<Employess>), typeof(EmployeeService));




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
