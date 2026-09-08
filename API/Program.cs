using API.Data;
using API.Interfaces;
using API.Middelware;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
}); 
builder.Services.AddControllers();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddCors();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
  
    var key = builder.Configuration["TokenKey"]??throw new InvalidOperationException("TokenKey not found in configuration.");
    options.TokenValidationParameters=new Microsoft.IdentityModel.Tokens.TokenValidationParameters{
     
      ValidateIssuerSigningKey = true,
        IssuerSigningKey =  new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false};

});
   
var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200","http://localhost:4200"));  
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();



using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<AppDbContext>();
    await context.Database.MigrateAsync();
    await Seed.SeedUsers(context);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migration");
}

app.Run();
