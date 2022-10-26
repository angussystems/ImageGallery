using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddJsonOptions(configure =>
        configure.JsonSerializerOptions.PropertyNamingPolicy = null);

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

builder.Services.AddAccessTokenManagement();

// create an HttpClient used for accessing the API
builder.Services.AddHttpClient("APIClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ImageGalleryAPIRoot"]);
    client.DefaultRequestHeaders.Clear();
    client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
}).AddUserAccessTokenHandler();//send access token with each request;
//s
builder.Services.AddAuthentication(options => {
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;

}).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    //in case user is not allowed to see some specific page this page will display 
    options.AccessDeniedPath = "/Authentication/AccessDenied";
}).
AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options => { 
options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.Authority = "https://localhost:5001/";
    options.ClientId = "imagegalleryclient";
    options.ClientSecret = "secret";
    options.ResponseType = "code";
    //middle layer by default retuen openid and profile scope
    //options.Scope.Add("openid");
    //options.Scope.Add("profile");
    //middle layer by default set the callback URL to this endpoint
    //options.CallbackPath = new PathString("signin-oidc");
    //middle layer redirect to this path once its logout
    //options.SignedOutCallbackPath = new PathString("signout-callback-oidc");
    options.SaveTokens = true;
    //Get claims from IDP user endpoint
    options.GetClaimsFromUserInfoEndpoint = true;
    //Removing claims which we dont need them
    options.ClaimActions.Remove("aud");
    options.ClaimActions.DeleteClaim("sid");
    options.ClaimActions.DeleteClaim("idp");
    //get roles base scopes from IDP
    options.Scope.Add("roles");
    options.Scope.Add("imagegalleryapi.fullaccess");
    //becasue we defined role a custom claim so we need to map that
    options.ClaimActions.MapJsonKey("role", "role");
    //tells the framwork where to find role claim
    options.TokenValidationParameters = new()
    {
        NameClaimType = "given_name",
        RoleClaimType = "role"
    };

});


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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Gallery}/{action=Index}/{id?}");
app.Run();
