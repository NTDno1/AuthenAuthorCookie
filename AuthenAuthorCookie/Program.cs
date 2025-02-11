using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
var urls = Environment.GetEnvironmentVariable("ASPNETCORE_URLS");
Console.WriteLine($"ASPNETCORE_URLS: {urls}");
// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;

    //options.DefaultAuthenticateScheme = "Second-Cookie";
    //options.DefaultChallengeScheme = "Second-Cookie";
}).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.Cookie = new CookieBuilder()
    {
        Name = "NguyenTienDat",
    };
    options.LoginPath = "/api/account/unauthorized";
    options.LogoutPath = "/api/account/signout";
    options.AccessDeniedPath = "/api/account/forbidden";
}).AddCookie("Second-Cookie", options =>
{
    options.LoginPath = "/api/account/unauthorized-v2";
});

//builder.Services.AddAuthorization(options =>
//{
//    var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
//        CookieAuthenticationDefaults.AuthenticationScheme,
//        "Second-Cookie"
//        );
//    defaultAuthorizationPolicyBuilder = defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
//    options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
//});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();