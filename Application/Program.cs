using Core.Models.Account;
using Core.Models.Catalog;
using Data.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces.Repository;
using Services.Interfaces.Services;
using Services.Interfaces.Services.Authorization;
using Services.Interfaces.Services.Catalog;
using Services.Repository;
using Services.Services;
using Services.Services.Authorization;
using Services.Services.Catalog;

var webApplicationBuilder = WebApplication.CreateBuilder(args);

ConfigureDatabase(webApplicationBuilder);
ConfigureIdentity(webApplicationBuilder);
ConfigureMvc(webApplicationBuilder);
ConfigureServices(webApplicationBuilder);
ConfigureRepositories(webApplicationBuilder);
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
    builder.Services.AddTransient<ILoginService, LoginService>();
    builder.Services.AddTransient<IRegisterService, RegisterService>();
    builder.Services.AddTransient<IProfileService, ProfileService>();
    builder.Services.AddTransient<IBookService, BookService>();
    builder.Services.AddTransient<ICatalogService, CatalogService>();
}

void ConfigureRepositories(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<IRoleRepository, RoleRepository<IdentityRole>>();
    builder.Services.AddTransient<ICatalogRepository, CatalogRepository>();
}

void AddAuthorizationPolicies(WebApplicationBuilder builder)
{
    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("Patron", policy => policy.RequireRole("Patron"));
        options.AddPolicy("Student", policy => policy.RequireRole("Student"));
        options.AddPolicy("Teacher", policy => policy.RequireRole("Teacher"));
        options.AddPolicy("AssistantLibrarian", policy => policy.RequireRole("AssistantLibrarian"));
        options.AddPolicy("EventManagement", policy => policy.RequireRole("EventManagement"));
        options.AddPolicy("Administrator", policy => policy.RequireRole("Administrator"));
        options.AddPolicy("TechnicalStaff", policy => policy.RequireRole("TechnicalStaff"));
        options.AddPolicy("Librarian", policy => policy.RequireRole("Librarian"));
        options.AddPolicy("Researcher", policy => policy.RequireRole("Researcher"));
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