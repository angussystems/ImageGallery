using ImageGallery.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MRI.ImageGallery.API.DbContexts;
using MRI.ImageGallery.API.Services;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(configure => configure.JsonSerializerOptions.PropertyNamingPolicy = null);


builder.Services.AddDbContext<ImageGalleryContext>(options => { 
options.UseSqlServer(builder.Configuration["ConnectionStrings:ImageGalleryDBConnectionString"]);
});

builder.Services.AddScoped<IImageGalleryRepository, ImageGalleryRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// clear default claims from access token
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

//Secure API so that they acquire breaer token
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        //IDP URL
        options.Authority = "https://localhost:5001";
        //api resource defined in IDP
        options.Audience = "imagegalleryapi";
        //Validate access toke header
        options.TokenValidationParameters = new()
        {
            ValidTypes = new[] { "at+jwt" },
            NameClaimType="given_name",
            RoleClaimType="role"
            
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
