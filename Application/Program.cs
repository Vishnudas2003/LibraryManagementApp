using API.Service.Interface.Repository;
using API.Service.Interface.Service;
using API.Service.Repository;
using API.Service.Service;
using Core.Models.Account;
using Core.Models.Catalog;
using Data.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Interface.Repository;
using Services.Interface.Service.Authorization;
using Services.Interface.Service.Catalog;
using Services.Repository;
using Services.Service.Authorization;
using Services.Service.Catalog;

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

void ConfigureIdentity(IHostApplicationBuilder builder)
{
    builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddRoles<IdentityRole>()
        .AddDefaultTokenProviders();
}

void ConfigureMvc(IHostApplicationBuilder builder)
{
    builder.Services.AddControllersWithViews()
        .AddViewOptions(options => { options.HtmlHelperOptions.ClientValidationEnabled = true; });
    
    builder.Services.AddHttpClient();
}

void ConfigureServices(IHostApplicationBuilder builder)
{
    builder.Services.AddTransient<ILoginService, LoginService>();
    builder.Services.AddTransient<IRegisterService, RegisterService>();
    builder.Services.AddTransient<IProfileService, ProfileService>();
    builder.Services.AddTransient<IBookService, BookService>();
    builder.Services.AddTransient<ICatalogService, CatalogService>();
    builder.Services.AddTransient<IAuthorizationService, AuthorizationService>();
    
    builder.Services.AddTransient<IBookRequestService, BookRequestService>();
    builder.Services.AddTransient<IBookRepository, BookRepository>();
}

void ConfigureRepositories(IHostApplicationBuilder builder)
{
    builder.Services.AddTransient<IRoleRepository, RoleRepository<IdentityRole>>();
    builder.Services.AddTransient<ICatalogRepository, CatalogRepository>();
    builder.Services.AddTransient<IGenericRepository<Book>, GenericRepository<Book>>();
}

void AddAuthorizationPolicies(IHostApplicationBuilder builder)
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

void ConfigureCookie(IHostApplicationBuilder builder)
{
    builder.Services.ConfigureApplicationCookie(options => { options.AccessDeniedPath = "/Home/AccessDenied"; });
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