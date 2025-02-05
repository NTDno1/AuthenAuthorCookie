using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

{
    if (app.Environment.IsDevelopment())
        app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();