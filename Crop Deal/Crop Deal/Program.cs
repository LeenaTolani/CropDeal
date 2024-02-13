using Crop_Deal.Interface;
using Crop_Deal.Model;
using Crop_Deal.Repository;
using Crop_Deal.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// For joining the tables
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.MaxDepth = 128; // Adjust as needed
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
}
);

//CORS header
builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod())
);

builder.Services.AddDbContext<CropDetailDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("UserConnectionString")));


// User Dependency Injection
builder.Services.AddScoped<IUser, UserRepo>();
builder.Services.AddScoped<UserServices,UserServices>();
// Bank Dependency Injection
builder.Services.AddScoped<IBankDetails, BankDetailsRepo>();
builder.Services.AddScoped<BankDetailsServices, BankDetailsServices>();
// Crop Dependency Injection
builder.Services.AddScoped<ICropDetails, CropDetailsRepo>();
builder.Services.AddScoped<CropDetailsServices, CropDetailsServices>();
// Crop Type Dependency Injection
builder.Services.AddScoped<ICropType, CropTypeRepo>();
builder.Services.AddScoped<CropTypeServices, CropTypeServices>();
// Subscribe Dependency Injection
builder.Services.AddScoped<ISubscribe, SubscribeRepo>();
builder.Services.AddScoped<SubscribeServices, SubscribeServices>();
//Login Dependency Injection
builder.Services.AddScoped<ILogin, LoginRepo>();
builder.Services.AddScoped<LoginService, LoginService>();
// Receipt Dependency Injection
builder.Services.AddScoped<IReceipt, ReceiptRepo>();
builder.Services.AddScoped<ReceiptServices, ReceiptServices>();

//JWT
var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
