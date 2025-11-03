using Microsoft.EntityFrameworkCore;
using StudentTrackerAPI.Services;
using Microsoft.AspNetCore.Identity;
using StudentTrackerAPI.Models.Entities;


var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5264")
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials();
                      });
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddOpenApiDocument();
builder.Services.AddScoped<IStudentRepository, DbStudentRepository>();

// DbContext Configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(
    builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Identity DbContext Configuration
builder.Services.AddDbContext<ApplicationIdentityDbContext>(options =>
        options.UseSqlite(
            builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Add Identity API Endpoints
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationIdentityDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    // Allows the cookie to be sent in cross-site requests
    options.Cookie.SameSite = SameSiteMode.None;

    // For local development on HTTP, you may need to explicitly disable Secure
    // since SameSite=None usually requires Secure=true.
    // NOTE: If you are using HTTPS on localhost, this is not needed.
    options.Cookie.SecurePolicy = CookieSecurePolicy.None; // Set to Always if using HTTPS
                                                           // OR set to None if you are ONLY using HTTP for local dev (less secure)
                                                           // options.Cookie.SecurePolicy = CookieSecurePolicy.None; 


    // Set a recognizable cookie name if you want to inspect it
    options.Cookie.Name = ".AspNetCore.Identity.Application.Api";
    options.Cookie.HttpOnly = true;
});

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapIdentityApi<IdentityUser>();

if (app.Environment.IsDevelopment())
{
    // Add OpenAPI 3.0 document serving middleware
    // Available at: http://localhost:<port>/swagger/v1/swagger.json
    app.UseOpenApi();

    // Add web UIs to interact with the document
    // Available at: http://localhost:<port>/swagger
    app.UseSwaggerUi(); // UseSwaggerUI Protected by if (env.IsDevelopment())
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
