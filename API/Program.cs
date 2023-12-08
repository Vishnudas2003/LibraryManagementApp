using API.Service.Interface;
using API.Service.Service;
using Core.Models.Account;
using Data.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var webApplicationBuilder = WebApplication.CreateBuilder(args);

ConfigureApi(webApplicationBuilder);
ConfigureDatabase(webApplicationBuilder);
ConfigureIdentity(webApplicationBuilder);
ConfigureServices(webApplicationBuilder);
AddAuthorizationPolicies(webApplicationBuilder);

var app = webApplicationBuilder.Build();

ConfigurePipeline(app);

app.Run();

void ConfigureApi(WebApplicationBuilder builder)
{
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

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

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<IBookRequestService, BookRequestService>();
    builder.Services.AddHttpClient();
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
    // Configure the HTTP request pipeline.
    // if (webApp.Environment.IsDevelopment())
    // {
    //     webApp.UseSwagger();
    //     webApp.UseSwaggerUI();
    // }

    webApp.UseHttpsRedirection();
    webApp.UseAuthorization();
    webApp.MapControllers();
}