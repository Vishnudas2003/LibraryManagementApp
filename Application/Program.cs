using Core.Models.Account;
using Data.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces.Repository;
using Services.Repository;
using Services.Services;

var webApplicationBuilder = WebApplication.CreateBuilder(args);

ConfigureDatabase(webApplicationBuilder);
ConfigureIdentity(webApplicationBuilder);
ConfigureMvc(webApplicationBuilder);
ConfigureServices(webApplicationBuilder);
ConfigureInterfaces(webApplicationBuilder);
AddAuthorizationPolicies(webApplicationBuilder);
ConfigureCookie(webApplicationBuilder);

var app = webApplicationBuilder.Build();

ConfigurePipeline(app);

app.Run();

void ConfigureDatabase(WebApplicationBuilder builder)
{
    var connectionString = builder.Configuration.GetConnectionString("ApplicationContextConnection") ??
                           throw new InvalidOperationException("No DB Connection Found.");

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));
}

void ConfigureIdentity(WebApplicationBuilder builder)
{
    builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddRoles<IdentityRole>()
        .AddDefaultTokenProviders();
}

void ConfigureMvc(WebApplicationBuilder builder)
{
    builder.Services.AddControllersWithViews()
        .AddViewOptions(options => { options.HtmlHelperOptions.ClientValidationEnabled = true; });
}

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<RegisterService>();
}

void ConfigureInterfaces(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<IUserRepository<ApplicationUser>, UserRepository<ApplicationUser>>();
    builder.Services.AddTransient<IRoleRepository, RoleRepository<IdentityRole>>();
}

void AddAuthorizationPolicies(WebApplicationBuilder builder)
{
    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("Customer", policy => policy.RequireRole("Customer"));
        options.AddPolicy("BankEmployee", policy => policy.RequireRole("BankEmployee"));
        options.AddPolicy("BankAdmin", policy => policy.RequireRole("BankAdmin"));
        options.AddPolicy("Teller", policy => policy.RequireRole("Teller"));
        options.AddPolicy("LoanOfficer", policy => policy.RequireRole("LoanOfficer"));
        options.AddPolicy("SystemAdministrator", policy => policy.RequireRole("SystemAdministrator"));
        options.AddPolicy("Auditor", policy => policy.RequireRole("Auditor"));
        options.AddPolicy("FraudAnalyst", policy => policy.RequireRole("FraudAnalyst"));
    });
}

void ConfigurePipeline(WebApplication webApp)
{
    if (!webApp.Environment.IsDevelopment())
    {
        webApp.UseExceptionHandler("/Shared/Error");
        webApp.UseHsts();
    }

    webApp.UseHttpsRedirection();
    webApp.UseStaticFiles();
    webApp.UseRouting();
    webApp.UseAuthentication();
    webApp.UseAuthorization();

    webApp.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
}

void ConfigureCookie(WebApplicationBuilder builder)
{
    builder.Services.ConfigureApplicationCookie(options => { options.AccessDeniedPath = "/Home/AccessDenied"; });
}